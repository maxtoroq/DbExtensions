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

try {

   [xml]$noticeDoc = Get-Content $solutionPath\NOTICE.xml
   $notice = $noticeDoc.DocumentElement

   if (-not (Test-Path nupkg -PathType Container)) {
      md nupkg | Out-Null
   }

   $outputPath = Resolve-Path nupkg

   MSBuild $solutionPath\DbExtensions.sln -t:Restore

   # build project
   BuildProj DbExtensions "Build"

   # build API docs (transforms assembly XML doc)
   .\build-docs.ps1 -NoBuildProj -XmlOnly

   # pack with modified XML doc
   BuildProj DbExtensions "Pack"

   # build QE
   BuildProj DbExtensions-QE "Build"

   # pack QE
   BuildProj DbExtensions-QE "Pack"

} finally {
   Pop-Location
}
