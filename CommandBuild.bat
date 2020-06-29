set UNITYPATH="C:\Program Files\Unity\2020.1.0b12\Editor\"
echo %UNITYPATH%
%UNITYPATH%Unity.exe -quit -batchmode -executeMethod BuildExample.CommandBuild "batファイルからのテキスト"
