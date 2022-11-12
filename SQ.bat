sonarscanner begin /k:"TDG" /d:sonar.host.url="http://localhost:9000"  /d:sonar.login="sqp_0e23418f25f27153635a74f4f1d5fbb55f3f913e"
dotnet build
pause
dotnet sonarscanner end /d:sonar.login="sqp_0e23418f25f27153635a74f4f1d5fbb55f3f913e"