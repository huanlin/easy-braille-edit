@echo off
xcopy /Y /E ..\build\Releases\v2.7.0\*.* InnoSetup\Files\*.*
del InnoSetup\Files\x86\*.pdb