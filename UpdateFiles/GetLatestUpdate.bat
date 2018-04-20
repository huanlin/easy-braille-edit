@echo off
copy ..\Doc\ChangeLog.txt
copy ..\Output\net452\*.exe 
copy ..\Output\net452\*.dll 
copy ..\Output\net452\*.ini 
copy ..\Output\net452\*.phf 
copy ..\Output\net452\EasyBrailleEdit.exe.config
copy ..\Output\net452\Txt2Brl.config

echo Remember to modify Update.txt.
pause