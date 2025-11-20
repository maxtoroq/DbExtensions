param(
   [Parameter(Mandatory=$true)][Version]$AssemblyVersion,
   [Parameter(Mandatory=$true)][Version]$PackageVersion,
   [Parameter()][string]$PreRelease
)

$ErrorActionPreference = "Stop"
Push-Location (Split-Path $script:MyInvocation.MyCommand.Path)

$solutionPath = Resolve-Path ..
$configuration = "Release"

function ProjectPath([string]$projName) {
   Resolve-Path $solutionPath\src\$projName
}

function ProjectFile([string]$projName) {
   $projPath = ProjectPath $projName
   return "$projPath\$projName.csproj"
}

function BuildProj([string]$projName, [string]$target) {

   $pack = $target -eq "Pack"

   MSBuild $(ProjectFile($projName)) /t:$target /v:minimal `
      /p:NoBuild=$pack `
      /p:Configuration=$configuration `
      /p:PackageOutputPath=$outputPath `
      /p:AssemblyVersion=$AssemblyVersion `
      /p:FileVersion=$PackageVersion `
      /p:VersionPrefix=$PackageVersion `
      /p:VersionSuffix=$PreRelease `
      /p:ContinuousIntegrationBuild=true `
      /p:GenerateDocumentationFile=$(-not $pack) `
      /p:Authors=$($notice.authors) `
      /p:Product=$($notice.work) `
      /p:Copyright=$($notice.copyright) `
      /p:Company=$($notice.website) `
      /p:PackageLicenseExpression=$($notice.license.name) `
      /p:PackageProjectUrl=$($notice.website) `
      /p:PackageReleaseNotes="For a list of changes see $($notice.website)docs/7/changes.html" `
      /p:RepositoryBranch=$(git branch --show-current)
}

function NuPack([string]$projName) {

   BuildProj $projName "Build" | Out-Host

   .\build-docs.ps1 -ProjectName $projName -NoBuildProj -XmlOnly | Out-Host

   BuildProj $projName "Pack" | Out-Host

   return Join-Path $outputPath "$projName.$pkgVer.nupkg"
}

function Prompt-Choices($Choices=("&Yes", "&No"), [string]$Title="Confirm", [string]$Message="Are you sure?", [int]$Default=0) {

   $choicesArr = [Management.Automation.Host.ChoiceDescription[]] `
      ($Choices | % {New-Object Management.Automation.Host.ChoiceDescription $_})

   return $host.ui.PromptForChoice($Title, $Message, $choicesArr, $Default)
}

try {

   [xml]$noticeDoc = Get-Content $solutionPath\NOTICE.xml
   $notice = $noticeDoc.DocumentElement

   if (-not (Test-Path nupkg -PathType Container)) {
      md nupkg | Out-Null
   }

   $outputPath = Resolve-Path nupkg

   $pkgVer = $PackageVersion.ToString(3)

   if ($PreRelease) {
      $pkgVer = $pkgVer + "-" + $PreRelease
   }

   $newTag = "v$pkgVer"

   MSBuild $solutionPath\DbExtensions.sln -t:Restore

   $newPackages = (NuPack DbExtensions), (NuPack DbExtensions-QE)

   if ((Prompt-Choices -Message "Create tag $newTag ?" -Default 1) -eq 0) {

      git tag -a $newTag -m $newTag
      Write-Warning "Created tag: $newTag"

      if ((Prompt-Choices -Message "Push package(s) to gallery?" -Default 1) -eq 0) {
         foreach ($pkgPath in $newPackages) {
            dotnet nuget push $pkgPath --source nuget.org
         }
      }

      if ((Prompt-Choices -Message "Push new tag $newTag to origin?" -Default 1) -eq 0) {
         git push origin $newTag
      }
   }

} finally {
   Pop-Location
}
