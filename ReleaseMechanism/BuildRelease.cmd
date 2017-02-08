call "%PROGRAMFILES(X86)%\Microsoft Visual Studio 9.0\VC\bin\vcvars32.bat"
MSBuild "%~dp0..\PowerPack.sln" /p:Configuration="Package For Release" /t:Rebuild