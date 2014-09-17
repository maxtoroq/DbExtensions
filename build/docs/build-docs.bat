MSBuild.exe %~dp0..\..\src\DbExtensions\DbExtensions.csproj /p:Configuration=Release
MSBuild.exe %~dp0DbExtensions.shfbproj
MSBuild.exe %~dp0..\..\submodules\sandcastle-md\sandcastle-md.sln
rd /s /q %~dp0..\..\docs\api
%~dp0..\..\submodules\sandcastle-md\src\sandcastle-md\bin\Debug\sandcastle-md.exe %~dp0output %~dp0..\..\docs\api
