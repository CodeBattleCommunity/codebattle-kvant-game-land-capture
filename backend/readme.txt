### Development environment
```
dotnet run --environment=Development
```

docker build -t pointwar .
docker run --rm -it -p 443:443/tcp -p 80:80/tcp pointwar:latest

