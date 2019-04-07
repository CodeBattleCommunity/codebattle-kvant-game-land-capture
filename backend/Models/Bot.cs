using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace CodeBattle.PointWar.Server.Models
{
    public class Bot : Hub
    {
        public int X_Bot { get; set; }
        public int Y_Bot { get; set; }
        public string PlayerID { get; set; }
    }
}
