param([switch]$NoBuildProj, [switch]$XmlOnly)

$ErrorActionPreference = "Stop"
Push-Location (Split-Path $script:MyInvocation.MyCommand.Path)

try {

   $nuget = ..\ensure-nuget.ps1

   if (-not (Test-Path EWSoftware.SHFB -PathType Container)) {
      &$nuget install EWSoftware.SHFB -Version 2019.6.24 -ExcludeVersion
   }

   if (-not (Test-Path EWSoftware.SHFB.NETFramework -PathType Container)) {
      &$nuget install EWSoftware.SHFB.NETFramework -Version 4.6.0 -ExcludeVersion
   }

   if (-not $NoBuildProj) {
      MSBuild.exe ..\..\src\DbExtensions\DbExtensions.csproj /v:minimal /p:Configuration=Release
   }

   MSBuild.exe DbExtensions.shfbproj /v:minimal

   if (-not $XmlOnly) {

      &$nuget restore sandcastle-md\sandcastle-md.sln
      MSBuild.exe sandcastle-md\sandcastle-md.sln /v:minimal

      if (Test-Path ..\..\docs\api -PathType Container) {
         rm ..\..\docs\api -Recurse
      }

      sandcastle-md\src\sandcastle-md\bin\Debug\sandcastle-md.exe api\html ..\..\docs\api
   }

} finally {
   Pop-Location
}
