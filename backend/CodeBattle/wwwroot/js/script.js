const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/signalr")
    .configureLogging(signalR.LogLevel.Information)
    .build();

hubConnection.start().then(function () {
    console.log("connected");
});
