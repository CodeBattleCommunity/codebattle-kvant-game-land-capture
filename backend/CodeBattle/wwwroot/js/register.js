 function CreateUser(userEmail, userPass) {
     $.ajax({
         url: "api/players",
         contentType: "application/json",
         method: "POST",
         data: JSON.stringify({
             Email : userEmail,
             Password : userPass
         }),
     })
}

function EditUser(userId, userEmail, userPass) {
    $.ajax({
        url: "api/users",
        contentType: "application/json",
        method: "PUT",
        data: JSON.stringify({
            ID: userId,
            Email: userEmail,
            Password: userPass
        }),
    })
}

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
