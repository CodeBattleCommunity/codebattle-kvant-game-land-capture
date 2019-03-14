$(document).ready(function() {
    
    
    $("div#password").width($("input").outerWidth(false));
    $("div#password").height($("input").outerHeight(false)); 
    
    $("input").keypress(function() {
        $("div#password").append("<img src=\"" + imgSrc + "\">");
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
	var elem_1 = getElementsById(elem1);
	var elem_2 = getElementsById(elem2);
	var e_mail = getElementsById(email);
	if (elem_1 === null || elem_2 === null || e_mail === null){
		alert("Пожалуйста, заполните все формы");
	}
}
