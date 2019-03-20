using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace CodeBattle.PointWar.Server.Models
{
    public class Bot : Hub
    {
        public int X_Bot { get; set; }
        public int Y_Bot { get; set; }

        Block BlockCoord = new Block();
        Point PointCoord = new Point();
        
        // Вверх
        public async Task Up(int y_bot, int x_bot)
        {
            if (BlockCoord.IsBlockY(y_bot - 1) == false)
            {
                Y_Bot = y_bot;
                X_Bot = x_bot;
                await Clients.All.SendAsync("Up", Y_Bot--, X_Bot); // Отправка на frontend
            }
            else
            {
                Y_Bot = y_bot;
                X_Bot = x_bot;
                await Clients.All.SendAsync("Up", Y_Bot, X_Bot); // Отправка на frontend
            }
        }
        
        // Вниз
        public async Task Down(int y_bot, int x_bot)
        {
            if (BlockCoord.IsBlockY(y_bot + 1) == false)
            {
                Y_Bot = y_bot;
                X_Bot = x_bot;
                await Clients.All.SendAsync("Down", Y_Bot++, X_Bot); // Отправка на frontend
            }
            else
            {
                Y_Bot = y_bot;
                X_Bot = x_bot;
                await Clients.All.SendAsync("Down", Y_Bot, X_Bot); // Отправка на frontend
            }
        }
        
        //Влево
        public async Task Left(int y_bot, int x_bot)
        {
            if (BlockCoord.IsBlockX(x_bot - 1) == false)
            {
                Y_Bot = y_bot;
                X_Bot = x_bot;
                await Clients.All.SendAsync("Left", Y_Bot, X_Bot--); // Отправка на frontend
            }
            else
            {
                Y_Bot = y_bot;
                X_Bot = x_bot;
                await Clients.All.SendAsync("Left", Y_Bot, X_Bot); // Отправка на frontend
            }
        }
        
        // Вправо
        public async Task Right(int y_bot, int x_bot)
        {
            if (BlockCoord.IsBlockX(x_bot + 1) == false)
            {
                Y_Bot = y_bot;
                X_Bot = x_bot;
                await Clients.All.SendAsync("Right", Y_Bot, X_Bot++); // Отправка на frontend
            }
            else
            {
                Y_Bot = y_bot;
                X_Bot = x_bot;
                await Clients.All.SendAsync("Right", Y_Bot, X_Bot); // Отправка на frontend
            }
        }
        
        // Поставить точку
        public async Task AddPoint(int y_bot, int x_bot)
        {
            int Y_Point = PointCoord.Y_Point;
            int X_Point = PointCoord.Y_Point;

            Y_Point = y_bot;
            X_Point = x_bot;

            await Clients.All.SendAsync("AddPoint", Y_Point, X_Point); // Отправка на frontend
        }
    }
}
