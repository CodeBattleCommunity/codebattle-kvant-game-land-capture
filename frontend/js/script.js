const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/command")
    .configureLogging(signalR.LogLevel.Information)
    .build();

hubConnection.on('Up', function (y_bot) {
    // �������� ���������� ���� (y)
});
hubConnection.on('Down', function (y_bot) {
    // �������� ���������� ���� (y)
});
hubConnection.on('Left', function (x_bot) {
    // �������� ���������� ���� (x)
});
hubConnection.on('Right', function (x_bot) {
    // �������� ���������� ���� (x)
});
hubConnection.on('AddPoint', function (y_point, x_point) {
    // �������� ���������� ���� (y, x). ������ �����
});

hubConnection.start().then(function () {
    console.log("connected");
});
