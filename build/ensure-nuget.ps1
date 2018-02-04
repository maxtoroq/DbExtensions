$ErrorActionPreference = "Stop"
Push-Location (Split-Path $script:MyInvocation.MyCommand.Path)

$nuget = "..\.nuget\nuget.exe"

try {

   $nugetDir = Split-Path $nuget

   if (-not (Test-Path $nugetDir -PathType Container)) {
      md $nugetDir | Out-Null
   }

   if (-not (Test-Path $nuget -PathType Leaf)) {
      write "Downloading NuGet..."
      Invoke-WebRequest https://dist.nuget.org/win-x86-commandline/latest/nuget.exe -OutFile $nuget
   }

} finally {
   Pop-Location
}
