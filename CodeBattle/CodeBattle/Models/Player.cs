using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace CodeBattle.Models
{
    public class Player
    {
        [BsonElement("ID")]
        [JsonProperty("id")]
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
    }
}
