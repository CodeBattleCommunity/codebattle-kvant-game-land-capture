const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/command")
    .configureLogging(signalR.LogLevel.Information)
    .build();

hubConnection.on('UpFront', function (y, x, id) {
    // Draw bot
});
hubConnection.on('DownFront', function (y, x, id) {
    // Draw bot
});
hubConnection.on('LeftFront', function (y, x, id) {
    // Draw bot
});
hubConnection.on('RightFront', function (y, x, id) {
    // Draw bot
});
hubConnection.on('AddPointFront', function (y, x, id) {
    // Draw point
});
hubConnection.on('GetCloseArea', function (list) {
    // List points - close area
});

hubConnection.start().then(function () {
    console.log("connected");
});
