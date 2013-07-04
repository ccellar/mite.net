@echo off
cls
"tools\nuget\nuget.exe" "install" "FAKE" "-OutputDirectory" "tools" "-ExcludeVersion"
"tools\nuget\nuget.exe" "install" "Nunit.Runners" "-OutputDirectory" "tools" "-ExcludeVersion"