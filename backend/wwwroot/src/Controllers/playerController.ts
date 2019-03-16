import axios from 'axios';

class PlayerController {

  public generateUUID(): string {
    let d = new Date().getTime();

    if (window.performance && typeof window.performance.now === 'function') {
        d += performance.now();
    }

    const uuid = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, (c) => {
        // tslint:disable-next-line:no-bitwise
        const r = (d + Math.random() * 16) % 16 | 0;
        d = Math.floor(d / 16);
        // tslint:disable-next-line:no-bitwise
        return (c === 'x' ? r : (r & 0x3 | 0x8)).toString(16);
    });
    return uuid;
  }

  public GetUsers() {
    return axios.get('/api/players');
  }

  public GetUser(id: number) {
    axios.get('/api/players/' + id);
  }

  public CreateUser(userEmail: string, userPass: string ) {
    return axios.post( 'api/players',
        {
          Email : userEmail,
          Password : userPass,
          Api_Key : this.generateUUID(),
        },
    );
  }

  public EditUser(userId: string, userEmail: string, userPass: string) {
    return axios.put('api/players',
      {
        ID: userId,
        Email: userEmail,
        Password: userPass,
      },
    );
  }

  public DeleteUser(id: string) {
    return axios.delete('api/users/' + id);
  }

//  $("form").submit(function (e) {
//    e.preventDefault();
//    var id = this.elements["id"].value;
//    var email = this.elements["Email"].value;
//    var password = this.elements["Password"].value;
//    if (id == 0)
//        CreateUser(email, password);
//    else
//        EditUser(id, email, password);
//  });
}
