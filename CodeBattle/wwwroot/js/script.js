const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/signalr") // Где обрабатывается
    .build();

// Тест
// получение сообщения от сервера
hubConnection.on('Receive', function (message, connectionId) {

    // создаем элемент <b> для имени идентификатора подключения
    let userNameElem = document.createElement("b");
    userNameElem.appendChild(document.createTextNode(connectionId + ": "));

    // создает элемент <p> для сообщения пользователя
    let elem = document.createElement("p");
    elem.appendChild(userNameElem);
    elem.appendChild(document.createTextNode(message));

    var firstElem = document.getElementById("chatroom").firstChild;
    document.getElementById("chatroom").insertBefore(elem, firstElem);

});

hubConnection.on('Notify', function (message) {

    // добавляет элемент для диагностического сообщения
    let notifyElem = document.createElement("b");
    notifyElem.appendChild(document.createTextNode(message));
    let elem = document.createElement("p");
    elem.appendChild(notifyElem);
    var firstElem = document.getElementById("chatroom").firstChild;
    document.getElementById("chatroom").insertBefore(elem, firstElem);
});

// отправка сообщения на сервер
document.getElementById("sendBtn").addEventListener("click", function (e) {
    let message = document.getElementById("message").value;
    hubConnection.invoke('Send', message);
});

hubConnection.start();
