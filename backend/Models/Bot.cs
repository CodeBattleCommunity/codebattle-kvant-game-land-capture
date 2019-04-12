using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace CodeBattle.PointWar.Server.Models
{
    public class Bot
    {
        public int X_Bot { get; set; }
        public int Y_Bot { get; set; }
        public string PlayerID { get; set; }

        public Bot(int y, int x, string playerId)
        {
            this.Y_Bot = y;
            this.X_Bot = x;
            this.PlayerID = playerId;
        }
    }
}
