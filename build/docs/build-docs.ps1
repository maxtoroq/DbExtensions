param([switch]$NoBuildProj, [switch]$XmlOnly)

$ErrorActionPreference = "Stop"
Push-Location (Split-Path $script:MyInvocation.MyCommand.Path)

try {

   $nuget = ..\ensure-nuget.ps1

   if (-not (Test-Path EWSoftware.SHFB -PathType Container)) {
      &$nuget install EWSoftware.SHFB -Version 2025.3.22 -ExcludeVersion
   }

   if (-not (Test-Path EWSoftware.SHFB.NET -PathType Container)) {
      &$nuget install EWSoftware.SHFB.NET -Version 5.0.0.2 -ExcludeVersion
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

      sandcastle-md\src\sandcastle-md\bin\Debug\sandcastle-md.exe api\html ..\..\docs\api `
        --remove-assembly-name `
        --remove-assembly-version `
        --exclude-icons
   }

} finally {
   Pop-Location
}
