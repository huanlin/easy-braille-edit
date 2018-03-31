@echo off
copy ..\Source\ReadMe\ChangeLog.txt
copy ..\Build\x86\Debug\*.exe 
copy ..\Build\x86\Debug\*.dll 
copy ..\Build\x86\Debug\*.ini 
copy ..\Build\x86\Debug\*.phf 
copy ..\Build\x86\Debug\EasyBrailleEdit.exe.config

echo Remember to modify Update.txt.
pause