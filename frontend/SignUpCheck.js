function check (form_id, email){
	var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
	var address = document.forms[form_id].elements[email].value;
	if(reg.test(address) == false) {
		alert('Введите корректный e-mail');
		return false;
	}
	else if(SignUp.pass1.value == 0 || SignUp.pass2.value == 0) {
		alert("Введите пароль");
		return false;
	}
	else if(SignUp.pass1.value != SignUp.pass2.value){
		alert("Пароли не совпадают");
		return false;
	}
	else if(SignUp.pass1.value == SignUp.pass2.value && SignUp.email.value != 0){
		alert("Регистрация успешна");
	}
}
function Reset(){
	SignUp.pass1.value = 0;
	SignUp.pass2.value = 0;
	SignUp.email.value = 0;
}