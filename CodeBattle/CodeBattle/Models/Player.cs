using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace CodeBattle.Models
{
    public class Player
    {
        [BsonId]
        [JsonProperty("id")]
        public int ID { get; }

        [JsonProperty("email")]
        [BsonElement("Email")]
        public string Email { get; }

        [JsonProperty("api_key")]
        [BsonElement("API_Key")]
        public string API_Key { get; }

        [JsonProperty("score")]
        [BsonElement("Score")]
        public int Score { get; }
    }
}
