const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/signalr")
    .configureLogging(signalR.LogLevel.Information)
    .build();

hubConnection.on('Up', function (y_bot, x_bot) {
    // �������� ���������� ���� (y)
});
hubConnection.on('Down', function (y_bot, x_bot) {
    // �������� ���������� ���� (y)
});
hubConnection.on('Left', function (x_bot, x_bot) {
    // �������� ���������� ���� (x)
});
hubConnection.on('Right', function (x_bot, x_bot) {
    // �������� ���������� ���� (x)
});
hubConnection.on('AddPoint', function (y_point, x_point) {
    // �������� ���������� ���� (y, x). ������ �����
});

hubConnection.start().then(function () {
    console.log("connected");
});
