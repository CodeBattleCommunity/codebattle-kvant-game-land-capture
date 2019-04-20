var app = new Vue({
    el: '#app',
    data:{name: 'Tom', age:25},
    methods:{
        welcome: function(){
            return "Welcome";
        },
        displayName: function() {
            return this.name;
        },
        factorial:function(n){
            var user = {
				name: "Tom",
				age: 23
			};
			var serializedUser = JSON.stringify(user);
			var request = new XMLHttpRequest();
			function reqReadyStateChange() {
				if (request.readyState == 4 && request.status == 200){
					return request.
				}
			}
			request.open("POST", "http://localhost:5000/api-v1/map");
			request.setRequestHeader('Content-Type', 'application/json');
			request.onreadystatechange = reqReadyStateChange;
			request.send(serializedUser);
			
            return "nice";
        }
    }
})
