using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace CodeBattle.Models
{
    //[WebMethod]
    public class Player
    {
        [BsonId]
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string API_Key { get; set; }

        // Регистрация
        public static async Task Register(string _email, string _password)
        {
            Player Player = new Player();

            Player.Email = _email;
            Player.Password = _password;

            string connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("CodeBattle");
            var collection = database.GetCollection<BsonDocument>("Players");
            BsonDocument Players = new BsonDocument
            {
                {"ID", Player.ID},
                {"Email", Player.Email},
                {"Password", Player.Password},
                {"API_Key", Player.API_Key},
            };
            await collection.InsertOneAsync(Players);
        }
    }
}
