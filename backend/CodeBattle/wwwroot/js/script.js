const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/signalr")
    .configureLogging(signalR.LogLevel.Information)
    .build();

hubConnection.on('Up', function (y_bot) {
    // Получаем координаты бота (y)
});
hubConnection.on('Down', function (y_bot) {
    // Получаем координаты бота (y)
});
hubConnection.on('Left', function (x_bot) {
    // Получаем координаты бота (x)
});
hubConnection.on('Right', function (x_bot) {
    // Получаем координаты бота (x)
});
hubConnection.on('AddPoint', function (y_point, x_point) {
    // Получаем координаты бота (y, x). Ставим точку
});

hubConnection.start().then(function () {
    console.log("connected");
});
