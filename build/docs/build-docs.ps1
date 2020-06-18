$ErrorActionPreference = "Stop"

Push-Location (Split-Path $script:MyInvocation.MyCommand.Path)

try {

   ../ensure-nuget.ps1

   $nuget = "..\..\.nuget\nuget.exe"

   if (-not (Test-Path EWSoftware.SHFB -PathType Container)) {
      &$nuget install EWSoftware.SHFB -Version 2019.6.24 -ExcludeVersion
   }

   if (-not (Test-Path EWSoftware.SHFB.NETFramework -PathType Container)) {
      &$nuget install EWSoftware.SHFB.NETFramework -Version 4.6.0 -ExcludeVersion
   }

   &$nuget restore sandcastle-md\sandcastle-md.sln
   
   MSBuild.exe sandcastle-md\sandcastle-md.sln
   MSBuild.exe ..\..\src\DbExtensions\DbExtensions.csproj /p:Configuration=Release
   MSBuild.exe DbExtensions.shfbproj
   
   if (Test-Path ..\..\docs\api -PathType Container) {
      rm ..\..\docs\api -Recurse
   }
   
   sandcastle-md\src\sandcastle-md\bin\Debug\sandcastle-md.exe api\html ..\..\docs\api

} finally {
   Pop-Location
}
