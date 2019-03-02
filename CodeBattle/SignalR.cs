using System;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CodeBattle
{
    public class SignalR : Hub
    {
        // Отправка сообщений ВСЕМ клиентам
        public async Task Send(string message)
        {
            await Clients.All.SendAsync("Receive", message);
        }
    }
}
