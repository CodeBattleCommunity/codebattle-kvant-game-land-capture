using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace CodeBattle.PointWar.Server.Models
{
        public class Map
        {
            [BsonElement("Height")]
            [JsonProperty("height")]
            public int Height { get; }

            [BsonElement("Width")]
            [JsonProperty("width")]
            public int Width { get;}
        
            [BsonElement("Index")]
            [JsonProperty("index")]
            public int Index { get; set; }

            [BsonElement("Link")]
            [JsonProperty("link")]
            public string Link { get; set; }

            [BsonElement("Ignore_Point")]
            [JsonProperty("ignore_point")]
            public Dictionary<int, double> Point { get; set; }

            // Need constructor for "_map" from Logic.cs
        }

}