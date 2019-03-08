// Получение всех пользователей
 function GetUsers() {
     $.ajax({
         url: '/api/users',
         type: 'GET',
         contentType: "application/json",
         success: function (users) {
             var rows = "";
             $.each(users, function (index, user) {
                 // добавляем полученные элементы в таблицу
                 rows += row(user);
             })
             $("table tbody").append(rows);
          }
     });
 }
 // Получение одного пользователя
 function GetUser(id) {
     $.ajax({
         url: '/api/users/'+id,
         type: 'GET',
         contentType: "application/json",
         success: function (user) {
             var form = document.forms["userForm"];
             form.elements["id"].value = user.id;
             form.elements["email"].value = user.email;
             form.elements["password"].value = user.password;
         }
     });
 }
 // Добавление пользователя
 function CreateUser(userEmail, userPass) {
     $.ajax({
         url: "api/users",
         contentType: "application/json",
         method: "POST",
         data: JSON.stringify({
             email: userEmail,
             password: userPass
         }),
         success: function (user) {
             reset();
             $("table tbody").append(row(user));
         }
     })
 }
 // Изменение пользователя
 function EditUser(userId, userEmail, userPass) {
     $.ajax({
         url: "api/users",
         contentType: "application/json",
         method: "PUT",
         data: JSON.stringify({
             id: userId,
             email: userEmail,
             password: userPass
         }),
         success: function (user) {
             reset();
             $("tr[data-rowid='" + user.id + "']").replaceWith(row(user));
         }
     })
 }

 // сброс формы
 function reset() {
     var form = document.forms["userForm"];
     form.reset();
     form.elements["id"].value = 0;
 }

 // Удаление пользователя
 function DeleteUser(id) {
     $.ajax({
         url: "api/users/"+id,
         contentType: "application/json",
         method: "DELETE",
         success: function (user) {
             $("tr[data-rowid='" + user.id + "']").remove();
         }
     })
 }
 // создание строки для таблицы
 var row = function (user) {
     return "<tr data-rowid='" + user.id + "'><td>" + user.id + "</td>" +
            "<td>" + user.email + "</td> <td>" + user.password + "</td>" +
            "<td><a class='editLink' data-id='" + user.id + "'>Изменить</a> | " +
             "<a class='removeLink' data-id='" + user.id + "'>Удалить</a></td></tr>";
 }
 // сброс значений формы
 $("#reset").click(function (e) {

     e.preventDefault();
     reset();
 })

 // отправка формы
 $("form").submit(function (e) {
     e.preventDefault();
     var id = this.elements["id"].value;
     var email = this.elements["email"].value;
     var password = this.elements["password"].value;
     if (id == 0)
         CreateUser(email, password);
     else
         EditUser(id, email, password);
 });

 // нажимаем на ссылку Изменить
 $("body").on("click", ".editLink", function () {
     var id = $(this).data("id");
     GetUser(id);
 })
 // нажимаем на ссылку Удалить
 $("body").on("click", ".removeLink", function () {
     var id = $(this).data("id");
     DeleteUser(id);
 })

 // загрузка пользователей
 GetUsers();
