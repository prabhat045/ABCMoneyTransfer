@echo off
echo Migration started...
cd "..\.."
powershell -Command "dotnet ef database update 2>&1 | Tee-Object -FilePath 'build\\Migrate\\ABCMoneyTransferMigrationLog.txt'"
IF ERRORLEVEL 1 (
    echo Migration failed. Check build\Migrate\ABCMoneyTransferMigrationLog.txt for details.
    pause
    EXIT /B 1
)
echo Migration completed successfully.
pause
