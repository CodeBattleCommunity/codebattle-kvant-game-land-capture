using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeBattle.Models
{
    
    public class User
    {
        [BsonElement("Username")]
        [JsonProperty("username")]
        public string UserName { get; }

        [BsonElement("Email")]
        [JsonProperty("email")]
        public string Email { get; }

        [BsonId]
        [JsonProperty("id")]
        public int ID { get; }

        [BsonElement("Password")]
        [JsonProperty("password")]
        public string Password { get; }

        [BsonElement("API_Key")]
        [JsonProperty("api_key")]
        public string API_Key { get; }
    }
}