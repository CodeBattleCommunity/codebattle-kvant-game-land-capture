using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeBattle.PointWar.Server.Models
{
    public class Map
    {
        [JsonProperty("height")]
        public int Height { get; set; }
        [JsonProperty("width")]
        public int Width { get; set; }
        [JsonProperty("index")]
        public int Index { get; set; }
        [JsonProperty("ignore_point")]
        public Dictionary<int, double> Point { get; set; }
    }
}