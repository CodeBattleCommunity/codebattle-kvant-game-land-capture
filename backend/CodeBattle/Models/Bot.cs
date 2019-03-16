using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace CodeBattle.Models
{
    public class Bot : Hub
    {
        public int X_Bot { get; set; }
        public int Y_Bot { get; set; }

        Block BlockCoord = new Block();
        Point PointCoord = new Point();

        public async Task Up(int y_bot)
        {
            if (BlockCoord.IsBlockY(y_bot - 1) == false)
            {
                Y_Bot = y_bot;
                await Clients.Caller.SendAsync("Up", Y_Bot--);
            }
            else
            {
                Y_Bot = y_bot;
                await Clients.Caller.SendAsync("Up", Y_Bot );
            }
        }
        
        public async Task Down(int y_bot)
        {
            if (BlockCoord.IsBlockY(y_bot + 1) == false)
            {
                Y_Bot = y_bot;
                await Clients.Caller.SendAsync("Down", Y_Bot++);
            }
            else
            {
                Y_Bot = y_bot;
                await Clients.Caller.SendAsync("Left", Y_Bot);
            }
        }
        
        public async Task Left(int x_bot)
        {
            if (BlockCoord.IsBlockX(x_bot - 1) == false)
            {
                X_Bot = x_bot;
                await Clients.Caller.SendAsync("Left", X_Bot--);
            }
            else
            {
                X_Bot = x_bot;
                await Clients.Caller.SendAsync("Left", X_Bot);
            }
        }
        
        public async Task Right(int x_bot)
        {
            if (BlockCoord.IsBlockX(x_bot + 1) == false)
            {
                X_Bot = x_bot;
                await Clients.Caller.SendAsync("Right", X_Bot++);
            }
            else
            {
                X_Bot = x_bot;
                await Clients.Caller.SendAsync("Right", X_Bot);
            }
        }
        
        public async Task AddPoint(int y_bot, int x_bot)
        {
            
        }
    }
}
