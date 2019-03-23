using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace CodeBattle.PointWar.Server.Models
{
    public class User
    {
        [JsonProperty("username")]
        [BsonElement("Username")]
        public string UserName { get; set; }

        [JsonProperty("email")]
        [BsonElement("Email")]        
        public string Email { get; set; }
        
        [JsonProperty("id")]        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]        
        public int Id { get; set; }

        [BsonElement("Password")]
        [JsonProperty("password")]
        public string Password { get; set; }
        
        [BsonElement("Token")]
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}