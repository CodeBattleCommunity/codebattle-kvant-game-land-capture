### Development environment
```
dotnet run --environment=Development
```
# Unix:
ASPNETCORE_URLS="https://*:5123" dotnet run

# Windows PowerShell:
$env:ASPNETCORE_URLS="https://*:5123" ; dotnet run

# Windows CMD (note: no quotes):
SET ASPNETCORE_URLS=https://*:5123 && dotnet run



dotnet CodeBattle.dll --server.urls "http://localhost:5101;http://*:5102"



docker build -t pointwar .
docker run --rm -it -p 443:443/tcp -p 80:80/tcp pointwar:latest

