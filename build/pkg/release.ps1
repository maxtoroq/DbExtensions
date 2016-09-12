param(
   [Parameter(Mandatory=$true, Position=0)][string]$ProjectName,
   [Parameter(Mandatory=$true)][Version]$AssemblyVersion,
   [Parameter(Mandatory=$true)][Version]$PackageVersion,
   [Parameter()][string]$PreRelease
)

$ErrorActionPreference = "Stop"
Push-Location (Split-Path $script:MyInvocation.MyCommand.Path)

$projectUrl = "http://maxtoroq.github.io/DbExtensions/"
$copyright = "2009-2016 Max Toro Q."

$solutionPath = Resolve-Path ..\..
$nuget = Join-Path $solutionPath .nuget\nuget.exe

function script:DownloadNuGet {

   $nugetDir = Split-Path $nuget

   if (-not (Test-Path $nugetDir -PathType Container)) {
      md $nugetDir | Out-Null
   }

   if (-not (Test-Path $nuget -PathType Leaf)) {
      write "Downloading NuGet..."
      Invoke-WebRequest https://www.nuget.org/nuget.exe -OutFile $nuget
   }
}

function script:RestorePackages {
   &$nuget restore $solutionPath\DbExtensions.sln
}

function script:NuSpec {

   $targetFx = $projDoc.DocumentElement.SelectSingleNode("*/*[local-name() = 'TargetFrameworkVersion']").InnerText
   $targetFxMoniker = "net" + $targetFx.Substring(1).Replace(".", "")

   "<package xmlns='http://schemas.microsoft.com/packaging/2010/07/nuspec.xsd'>"
      "<metadata>"
         "<id>$projName</id>"
         "<version>$pkgVersion</version>"
         "<authors>Max Toro Q.</authors>"
         "<licenseUrl>http://www.apache.org/licenses/LICENSE-2.0</licenseUrl>"
         "<projectUrl>$projectUrl</projectUrl>"
         "<iconUrl>$($projectUrl)nuget/icon.png</iconUrl>"
         "<releaseNotes>For a list of changes see $($projectUrl)docs/changes.html</releaseNotes>"

   if ($projName -eq "DbExtensions") {

      "<description>DbExtensions is a data-access framework with a strong focus on query composition, granularity and code aesthetics. It supports both POCO and dynamic (untyped) mapping.</description>"
      "<copyright>$copyright</copyright>"
      "<tags>ado.net orm micro-orm</tags>"

      "<frameworkAssemblies>"
         "<frameworkAssembly assemblyName='System.Core'/>"
         "<frameworkAssembly assemblyName='System.Data'/>"
         "<frameworkAssembly assemblyName='System.Data.Linq'/>"
      "</frameworkAssemblies>"
   }

   "</metadata>"

   "<files>"
      "<file src='$solutionPath\LICENSE.txt'/>"
      "<file src='$solutionPath\NOTICE.txt'/>"
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

   ## Create nuspec

   $pkgVersion = "$PackageVersion$(if ($PreRelease) { ""-$PreRelease"" } else { $null })"
   $nuspecPath = "$tempPath\$projName.nuspec"

   NuSpec | Out-File $nuspecPath -Encoding utf8

   ## Create assembly signature file

   $signaturePath = "$tempPath\AssemblySignature.cs"
   $signature = @"
using System;
using System.Reflection;

[assembly: AssemblyProduct("DbExtensions")]
[assembly: AssemblyCompany("$projectUrl")]
[assembly: AssemblyCopyright("$copyright")]
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