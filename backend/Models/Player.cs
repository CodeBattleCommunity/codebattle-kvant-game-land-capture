using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace CodeBattle.PointWar.Server.Models
{
    public class Player
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty("id")]
        public string ID { get; set; }

        [BsonElement("Email")]
        [JsonProperty("email")]
        public string Email { get; set; }

        [BsonElement("Password")]
        [JsonProperty("password")]
        public string Password { get; set; }

        [BsonElement("Score")]
        [JsonProperty("score")]
        public int Score { get; set; }

        
        [BsonElement("API_Key")]
        [JsonProperty("api_key")]
        public string API_Key { get; set; }

       /* public Player(string id, string email, string pass, string score, string api)
        {

        }*/
    }
}
