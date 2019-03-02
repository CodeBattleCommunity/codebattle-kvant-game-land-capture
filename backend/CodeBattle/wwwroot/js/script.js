const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/signalr") // Где обрабатывается
    .build();

hubConnection.start();
