function generateUUID() {
    var d = new Date().getTime();

    if (window.performance && typeof window.performance.now === "function") {
        d += performance.now();
    }

    var uuid = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = (d + Math.random() * 16) % 16 | 0;
        d = Math.floor(d / 16);
        return (c == 'x' ? r : (r & 0x3 | 0x8)).toString(16);
    });

    return uuid;
}

// Получение всех пользователей
function GetUsers() {
    $.ajax({
        url: '/api/players',
        type: 'GET',
        contentType: "application/json",
    });
}
// Получение одного пользователя
function GetUser(id) {
    $.ajax({
        url: '/api/players/' + id,
        type: 'GET',
        contentType: "application/json",
    });
}

// Добавление пользователя
function CreateUser(userEmail, userPass) {
     $.ajax({
         url: "api/players",
         contentType: "application/json",
         method: "POST",
         data: JSON.stringify({
             Email : userEmail,
             Password : userPass,
             Api_Key : generateUUID(),
         }),
     })
}

// Изменение пользователя
function EditUser(userId, userEmail, userPass) {
    $.ajax({
        url: "api/players",
        contentType: "application/json",
        method: "PUT",
        data: JSON.stringify({
            ID: userId,
            Email: userEmail,
            Password: userPass
        }),
    })
}

// Удаление пользователя
function DeleteUser(id) {
    $.ajax({
        url: "api/users/" + id,
        contentType: "application/json",
        method: "DELETE",
    })
}

// Кнопка регистрации
$("form").submit(function (e) {
    e.preventDefault();
    var id = this.elements["id"].value;
    var email = this.elements["Email"].value;
    var password = this.elements["Password"].value;
    if (id == 0)
        CreateUser(email, password);
    else
        EditUser(id, email, password);
});
