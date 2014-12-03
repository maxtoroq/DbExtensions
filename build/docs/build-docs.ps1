
$ErrorActionPreference = "Stop"

Push-Location (Split-Path $script:MyInvocation.MyCommand.Path)

try {

   $nuget = "..\..\.nuget\nuget.exe"

   # download nuget
   if (-not (Test-Path $nuget -PathType Leaf)) {

      if (-not (Test-Path ..\..\.nuget -PathType Container)) {
         md ..\..\.nuget | Out-Null
      }

      write "Downloading NuGet..."

      Invoke-WebRequest https://www.nuget.org/nuget.exe -OutFile $nuget
   }

   # download SHFB
   if (-not (Test-Path EWSoftware.SHFB -PathType Container)) {
      &$nuget install EWSoftware.SHFB -Version 2014.11.22 -ExcludeVersion
   }

   # compile sandcastle-md
   &$nuget restore sandcastle-md\sandcastle-md.sln
   MSBuild.exe sandcastle-md\sandcastle-md.sln
   
   # compile DbExtensions
   MSBuild.exe ..\..\src\DbExtensions\DbExtensions.csproj /p:Configuration=Release

   # run SHFB
   MSBuild.exe DbExtensions.shfbproj
   
   # clear output dir
   if (Test-Path ..\..\docs\api -PathType Container) {
      rm ..\..\docs\api -Recurse
   }
   
   # convert to markdown
   sandcastle-md\src\sandcastle-md\bin\Debug\sandcastle-md.exe output ..\..\docs\api

} finally {
   Pop-Location
}
