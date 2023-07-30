set PATH=%PATH%;"C:\Program Files\Microsoft Visual Studio\2022\Community\VC\Tools\MSVC\14.32.31326\bin\Hostx86\x86\"
set LIB=C:\Program Files\Microsoft Visual Studio\2022\Community\VC\Tools\MSVC\14.32.31326\ATLMFC\lib\x86;C:\Program Files\Microsoft Visual Studio\2022\Community\VC\Tools\MSVC\14.32.31326\lib\x86;C:\Program Files (x86)\Windows Kits\NETFXSDK\4.8\lib\um\x86;C:\Program Files (x86)\Windows Kits\10\lib\10.0.19041.0\ucrt\x86;C:\Program Files (x86)\Windows Kits\10\\lib\10.0.19041.0\\um\x86
cd C:\instit\kurs2\kurs\APV\astmbler
ml /c /coff asm.asm
link /OPT:NOREF /DEBUG asm.obj C:\instit\kurs2\kurs\APV\Debug\Project2.lib /SUBSYSTEM:CONSOLE /NODEFAULTLIB:library
asm.exe
pause