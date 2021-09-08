param(
   [Parameter(Mandatory=$true, Position=0)][string]$ProjectName,
   [Parameter(Mandatory=$true)][Version]$AssemblyVersion,
   [Parameter(Mandatory=$true)][Version]$PackageVersion,
   [Parameter()][string]$PreRelease
)

$ErrorActionPreference = "Stop"
Push-Location (Split-Path $script:MyInvocation.MyCommand.Path)

$solutionPath = Resolve-Path ..\..
$configuration = "Release"

function ProjectPath([string]$projName) {
   Resolve-Path $solutionPath\src\$projName
}

function ProjectFile([string]$projName) {
   $projPath = ProjectPath $projName
   return "$projPath\$projName.csproj"
}

function BuildProj([string]$projName, [string]$projFile, [string]$target) {

   $pack = $target -eq "Pack"

   if ($pack) {

      $projDoc = New-Object Xml.XmlDocument
      $projDoc.PreserveWhitespace = $true
      $projDoc.Load($projFile)

      $itemXml = "<ItemGroup xmlns='$($projDoc.DocumentElement.NamespaceURI)'>
         <None Include='$solutionPath\LICENSE.txt' Pack='true' PackagePath=''/>
         <None Include='$solutionPath\NOTICE.xml' Pack='true' PackagePath=''/>
         <None Include='$(Resolve-Path icon.png)' Pack='true' PackagePath=''/>
      </ItemGroup>"

      $itemReader = [Xml.XmlReader]::Create((New-Object IO.StringReader $itemXml))
      $itemReader.MoveToContent() | Out-Null
      $itemNode = $projDoc.ReadNode($itemReader)
      $projDoc.DocumentElement.AppendChild($itemNode) | Out-Null
      $itemNode.RemoveAttribute("xmlns")

      $projDoc.Save($projFile)
   }

   MSBuild $projFile /t:$target /v:minimal `
      /p:NoBuild=$pack `
      /p:Configuration=$configuration `
      /p:PackageOutputPath=$outputPath `
      /p:GenerateDocumentationFile=$(-not $pack) `
      /p:Product=$($notice.work) `
      /p:AssemblyVersion=$AssemblyVersion `
      /p:FileVersion=$PackageVersion `
      /p:VersionPrefix=$PackageVersion `
      /p:VersionSuffix=$PreRelease `
      /p:Authors=$($notice.authors) `
      /p:PackageLicenseExpression=$($notice.license.name) `
      /p:PackageProjectUrl=$($notice.website) `
      /p:Copyright=$($notice.copyright) `
      /p:Company=$($notice.website) `
      /p:PackageIcon=icon.png `
      /p:PackageReleaseNotes="For a list of changes see $($notice.website)docs/changes.html"

   if ($pack) {
      $projDoc.DocumentElement.RemoveChild($itemNode) | Out-Null
      $projDoc.Save($projFile)
   }
}

function NuPack([string]$projName) {

   $pkgVersion = "$PackageVersion$(if ($PreRelease) { ""-$PreRelease"" } else { $null })"
   $projPath = Resolve-Path $solutionPath\src\$projName
   $projFile = "$projPath\$projName.csproj"

   [xml]$noticeDoc = Get-Content $solutionPath\NOTICE.xml
   $notice = $noticeDoc.DocumentElement

   if (-not (Test-Path nupkg -PathType Container)) {
      md nupkg | Out-Null
   }

   $outputPath = Resolve-Path nupkg

   # build project
   BuildProj $projName $projFile "Build"

   # build API docs (transforms assembly XML doc)
   ..\docs\build-docs.ps1 -NoBuildProj -XmlOnly

   # pack
   BuildProj $projName $projFile "Pack"
}

try {

   $nuget = ..\ensure-nuget.ps1
   ..\restore-packages.ps1

   if ($ProjectName -eq '*') {
      NuPack DbExtensions
   } else {
      NuPack $ProjectName
   }

} finally {
   Pop-Location
}
