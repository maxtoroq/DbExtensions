param(
   [Parameter(Mandatory=$true, Position=0)][string]$ProjectName,
   [Parameter(Mandatory=$true)][Version]$AssemblyVersion,
   [Parameter(Mandatory=$true)][Version]$PackageVersion,
   [Parameter()][string]$PreRelease
)

$ErrorActionPreference = "Stop"
Push-Location (Split-Path $script:MyInvocation.MyCommand.Path)

$solutionPath = Resolve-Path ..\..
$nuget = Join-Path $solutionPath .nuget\nuget.exe

function script:DownloadNuGet {
   ../ensure-nuget.ps1
}

function script:RestorePackages {
   ../restore-packages.ps1
}

function script:NuSpec {

   $targetFx = $projDoc.DocumentElement.SelectSingleNode("*/*[local-name() = 'TargetFrameworkVersion']").InnerText
   $targetFxMoniker = "net" + $targetFx.Substring(1).Replace(".", "")

   "<package xmlns='http://schemas.microsoft.com/packaging/2010/07/nuspec.xsd'>"
      "<metadata>"
         "<id>$projName</id>"
         "<version>$pkgVersion</version>"
         "<authors>$($notice.authors)</authors>"
         "<licenseUrl>$($notice.license.url)</licenseUrl>"
         "<projectUrl>$($notice.website)</projectUrl>"
         "<iconUrl>$($notice.website)nuget/icon.png</iconUrl>"
         "<releaseNotes>For a list of changes see $($notice.website)docs/changes.html</releaseNotes>"

   if ($projName -eq "DbExtensions") {

      "<description>DbExtensions is a data-access framework with a strong focus on query composition, granularity and code aesthetics. It supports both POCO and dynamic (untyped) mapping.</description>"
      "<copyright>$($notice.copyright)</copyright>"
      "<tags>ado.net orm micro-orm</tags>"

      "<frameworkAssemblies>"
         "<frameworkAssembly assemblyName='System.Core'/>"
         "<frameworkAssembly assemblyName='System.Data'/>"
      "</frameworkAssemblies>"
   }

   "</metadata>"

   "<files>"
      "<file src='$solutionPath\LICENSE.txt'/>"
      "<file src='$solutionPath\NOTICE.xml'/>"
      "<file src='$projPath\bin\Release\$projName.dll' target='lib\$targetFxMoniker'/>"
      "<file src='$projPath\bin\Release\$projName.pdb' target='lib\$targetFxMoniker'/>"
      "<file src='$solutionPath\build\docs\api\xml\$projName.xml' target='lib\$targetFxMoniker'/>"
   "</files>"

   "</package>"
}

function script:NuPack([string]$projName) {

   $projPath = Resolve-Path $solutionPath\src\$projName
   $projFile = "$projPath\$projName.csproj"

   if (-not (Test-Path temp -PathType Container)) {
      md temp | Out-Null
   }

   if (-not (Test-Path temp\$projName -PathType Container)) {
      md temp\$projName | Out-Null
   }

   if (-not (Test-Path nupkg -PathType Container)) {
      md nupkg | Out-Null
   }

   $tempPath = Resolve-Path temp\$projName
   $outputPath = Resolve-Path nupkg

   ## Read project file

   $projDoc = New-Object Xml.XmlDocument
   $projDoc.PreserveWhitespace = $true
   $projDoc.Load($projFile)

   ## Create nuspec using info from project file and notice

   [xml]$noticeDoc = Get-Content $solutionPath\NOTICE.xml
   $notice = $noticeDoc.DocumentElement

   $pkgVersion = "$PackageVersion$(if ($PreRelease) { ""-$PreRelease"" } else { $null })"
   $nuspecPath = "$tempPath\$projName.nuspec"

   NuSpec | Out-File $nuspecPath -Encoding utf8

   ## Create assembly signature file

   $signaturePath = "$tempPath\AssemblySignature.cs"
   $signature = @"
using System;
using System.Reflection;

[assembly: AssemblyProduct("$($notice.work)")]
[assembly: AssemblyCompany("$($notice.website)")]
[assembly: AssemblyCopyright("$($notice.copyright)")]
[assembly: AssemblyVersion("$AssemblyVersion")]
[assembly: AssemblyFileVersion("$PackageVersion")]
[assembly: AssemblyInformationalVersion("$pkgVersion")]
"@

   $signature | Out-File $signaturePath -Encoding utf8

   ## Add signature to project file

   $signatureXml = "<ItemGroup xmlns='http://schemas.microsoft.com/developer/msbuild/2003'>
      <Compile Include='$signaturePath'>
         <Link>AssemblySignature.cs</Link>
      </Compile>
   </ItemGroup>"

   $signatureReader = [Xml.XmlReader]::Create((New-Object IO.StringReader $signatureXml))
   $signatureReader.MoveToContent() | Out-Null

   $signatureNode = $projDoc.ReadNode($signatureReader)

   $projDoc.DocumentElement.AppendChild($signatureNode) | Out-Null
   $signatureNode.RemoveAttribute("xmlns")

   $projDoc.Save($projFile)

   ## Build project and remove signature

   MSBuild $projFile /p:Configuration=Release /p:BuildProjectReferences=false

   $projDoc.DocumentElement.RemoveChild($signatureNode) | Out-Null
   $projDoc.Save($projFile)

   ## Create package

   &$nuget pack $nuspecPath -OutputDirectory $outputPath
}

try {

   DownloadNuGet
   RestorePackages

   if ($ProjectName -eq '*') {
      NuPack DbExtensions
   } else {
      NuPack $ProjectName
   }

} finally {
   Pop-Location
}