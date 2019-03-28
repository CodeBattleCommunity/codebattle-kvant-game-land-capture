using Newtonsoft.Json;

namespace CodeBattle.PointWar.Server.Models
{
    public class Point
    {
        [JsonProperty("X_Point")]
        public int X_Point { get; set; }
        [JsonProperty("Y_Point")]
        public int Y_Point { get; set; }
        [JsonProperty("Color")]
        public string Color { get; set; }
        public string serialize;
        
        public bool IsPoint(int y_point, int x_point)
        {
            if (y_point == Y_Point || x_point == X_Point) return true;
            return false;
        }

        public void AddPointJson(Point obj)
        {
            serialize = JsonConvert.SerializeObject(obj);
        }
    }
}