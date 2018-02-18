@echo off
copy ..\Source\ReadMe\ChangeLog.txt
copy ..\Build\x86\Release\*.exe 
copy ..\Build\x86\Release\*.dll 
copy ..\Build\x86\Release\*.ini 
copy ..\Build\x86\Release\*.phf 

echo Remember to modify Update.txt.
pause