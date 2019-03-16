using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace CodeBattle.Models
{
    public class Player
    {
        [BsonId]
        [JsonProperty("id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

        [JsonProperty("email")]
        [BsonElement("Email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        [BsonElement("Password")]
        public string Password { get; set; }

        [JsonProperty("score")]
        [BsonElement("Score")]
        public int Score { get; set; }

        [JsonProperty("api_key")]
        [BsonElement("API_Key")]
        public string API_Key { get; set; }
    }
}
