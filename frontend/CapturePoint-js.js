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
	var email_length = document.oForm.email.value.length;
	var index = 0;
	
	if (document.oForm.elem1.value === "" || document.oForm.elem2.value === "" || document.oForm.email.value === ""){
		alert("Пожалуйста, заполните все формы");
		valid = false;
	}
	else if (document.oForm.elem1.value !== document.oForm.elem2.value){
		alert("Пароли не совпадают!");
		valid = false;
	}
	/*while (index < email_length){
		
	}*/
	return valid;
}
