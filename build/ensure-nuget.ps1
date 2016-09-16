$ErrorActionPreference = "Stop"

Push-Location (Split-Path $script:MyInvocation.MyCommand.Path)

try {

   $nuget = "..\.nuget\nuget.exe"
   $nugetDir = Split-Path $nuget

   if (-not (Test-Path $nuget -PathType Leaf)) {

      if (-not (Test-Path $nugetDir -PathType Container)) {
         md $nugetDir | Out-Null
      }

      write "Downloading NuGet..."

      Invoke-WebRequest https://www.nuget.org/nuget.exe -OutFile $nuget
   }

} finally {
   Pop-Location
}
