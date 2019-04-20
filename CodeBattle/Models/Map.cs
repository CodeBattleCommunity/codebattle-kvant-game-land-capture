using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeBattle.Models
{
    public class Map
    {
        [BsonElement("Height")]
        [JsonProperty("height")]
        public int Height { get; set; }

        [BsonElement("Width")]
        [JsonProperty("width")]
        public int Width { get; set; }
        
        [BsonId]
        [JsonProperty("id")]
        public int Index { get; set; }

        [BsonElement("Link")]
        [JsonProperty("link")]
        public string Link { get; set; }

        [BsonElement("Ignore_Point")]
        [JsonProperty("ignore_point")]
        public Dictionary<int, double> Point { get; set; }
    }
}