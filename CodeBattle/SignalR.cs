using System;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Diagnostics;
using CodeBattle.Models;

namespace CodeBattle
{
    public class SignalR : Hub
    {
        Bot Player = new Bot();

        // Отправка сообщений ВСЕМ клиентам
        public async Task Send(string message)
        {
            await Clients.All.SendAsync("Receive", message);
        }
    }
}
