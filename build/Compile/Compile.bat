
cd "../.."
rd /s /q wwwroot\ABCMoneyTransferApp
dotnet build ABCMoneyTransfer.sln /flp:logfile=build\compile\ABCMoneyTransferBuildLog.txt
