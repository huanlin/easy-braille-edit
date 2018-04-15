@echo off
copy ..\Source\ReadMe\ChangeLog.txt
copy ..\Build\Debug\*.exe 
copy ..\Build\Debug\*.dll 
copy ..\Build\Debug\*.ini 
copy ..\Build\Debug\*.phf 
copy ..\Build\Debug\EasyBrailleEdit.exe.config

echo Remember to modify Update.txt.
pause