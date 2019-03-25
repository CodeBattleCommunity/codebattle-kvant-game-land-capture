using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace CodeBattle.PointWar.Server
{
    public class CommandHub : Hub
    {
        // Отправка сообщений ВСЕМ клиентам
        public async Task Send(string message)
        {
            await Clients.All.SendAsync("Receive", message);
        }
    }
}
