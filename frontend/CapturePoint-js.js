$(document).ready(function() {
    
    
    $("div#password").width($("input").outerWidth(false));
    $("div#password").height($("input").outerHeight(false)); 
    
    $("input").keypress(function() {
        $("div#password").append("<img src=\"" + this.imgSrc + "\">");
    });
    
    $("div#password").click(function() {
       $("input").focus(); 
    });
});
$('#registration input[type=email]').on('blur', function () {
  let email = $(this).val();
  
  if (email.length > 0
  && (email.match(/.+?\@.+/g) || []).length !== 1) {
    console.log('invalid');
    alert('Вы ввели некорректный e-mail!');
  } else {
    console.log('valid');
    alert('Вы ввели корректный e-mail!');
  }
});
function Regist(){
	var valid = true;
	//var email_length = document.oForm.email.value.length;
	//var index = 0;
	
	if (document.oForm.elem1.value === "" || document.oForm.elem2.value === "" || document.oForm.email.value === ""){
		alert("Пожалуйста, заполните все формы");
		valid = false;
	}
	else if (document.oForm.elem1.value !== document.oForm.elem2.value){
		alert("Пароли не совпадают!");
		valid = false;
	}
	else if (document.oForm.elem1.value.length < 6 && document.oForm.elem2.value.length < 6){
		alert("Пароль должен содержать не менее 6-ти символов");
		valid = false;
	}
	
	return valid;
}
function Show ()
{
  var elem = document.getElementById('password'); 
  if ( elem ) 
    elem.style.display = "block";
}
/*
Функция посылки запроса к файлу на сервере
r_method  - тип запроса: GET или POST
r_path    - путь к файлу
r_args    - аргументы вида a=1&b=2&c=3...
r_handler - функция-обработчик ответа от сервера
*/
function SendRequest(r_method, r_path, r_args, r_handler)
{
    //Создаём запрос
    var Request = CreateRequest();
    
    //Проверяем существование запроса еще раз
    if (!Request)
    {
        return;
    }
    
    //Назначаем пользовательский обработчик
    Request.onreadystatechange = function()
    {
        //Если обмен данными завершен
        if (Request.readyState == 4)
        {
            //Передаем управление обработчику пользователя
            r_handler(Request);
        }
    }
    
    //Проверяем, если требуется сделать GET-запрос
    if (r_method.toLowerCase() == "get" && r_args.length > 0)
    r_path += "?" + r_args;
    
    //Инициализируем соединение
    Request.open(r_method, r_path, true);
    
    if (r_method.toLowerCase() == "post")
    {
        //Если это POST-запрос
        
        //Устанавливаем заголовок
        Request.setRequestHeader("Content-Type","application/x-www-form-urlencoded; charset=utf-8");
        //Посылаем запрос
        Request.send(r_args);
    }
    else
    {
        //Если это GET-запрос
        
        //Посылаем нуль-запрос
        Request.send(null);
    }
} 
