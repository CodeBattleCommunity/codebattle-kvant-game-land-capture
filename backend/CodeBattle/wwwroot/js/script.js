const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/signalr")
    .build();

hubConnection.start();
