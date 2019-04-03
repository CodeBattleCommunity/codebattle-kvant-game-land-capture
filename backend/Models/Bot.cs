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

        Block BlockCoord = new Block();
        Point PointCoord = new Point();
        
        // Вверх
        public async Task Up(Player _player, Bot _bot)
        {
            Bot bot = new Bot();
            
            bot.X_Bot = _bot.X_Bot;
            bot.Y_Bot = _bot.Y_Bot;
            bot.PlayerID = _player.ID;
            
            if (BlockCoord.IsBlock(bot.Y_Bot--, bot.X_Bot) == false)
            {
                bot.Y_Bot--;
                await Clients.All.SendAsync("Up", bot); // Отправка клиентам
            }
            else
            {
                await Clients.All.SendAsync("Up", bot); // Отправка клиентам
            }
        }
        
        // Вниз
        public async Task Down(Player _player, Bot _bot)
        {
            Bot bot = new Bot();
            
            bot.X_Bot = _bot.X_Bot;
            bot.Y_Bot = _bot.Y_Bot;
            bot.PlayerID = _player.ID;
            
            if (BlockCoord.IsBlock(bot.Y_Bot++, bot.X_Bot) == false)
            {
                bot.Y_Bot++;
                await Clients.All.SendAsync("Down", bot); // Отправка клиентам
            }
            else
            {
                await Clients.All.SendAsync("Down", bot); // Отправка клиентам
            }
        }
        
        //Влево
        public async Task Left(Player _player, Bot _bot)
        {
            Bot bot = new Bot();
            
            bot.X_Bot = _bot.X_Bot;
            bot.Y_Bot = _bot.Y_Bot;
            bot.PlayerID = _player.ID;
            
            if (BlockCoord.IsBlock(bot.Y_Bot, bot.X_Bot--) == false)
            {
                bot.X_Bot--;
                await Clients.All.SendAsync("Left", bot); // Отправка клиентам
            }
            else
            {
                await Clients.All.SendAsync("Left", bot); // Отправка клиентам
            }
        }
        
        // Вправо
        public async Task Right(Player _player, Bot _bot)
        {
            Bot bot = new Bot();
            
            bot.X_Bot = _bot.X_Bot;
            bot.Y_Bot = _bot.Y_Bot;
            bot.PlayerID = _player.ID;
            
            if (BlockCoord.IsBlock(bot.Y_Bot, bot.X_Bot++) == false)
            {
                bot.Y_Bot++;
                await Clients.All.SendAsync("Right", bot); // Отправка клиентам
            }
            else
            {
                await Clients.All.SendAsync("Right", bot); // Отправка клиентам
            }
        }
        
        // Поставить точку
        public async Task AddPoint(Point _point)
        {
            Point point = new Point();

            point.X_Point = _point.X_Point;
            point.Y_Point = _point.Y_Point;
            point.PlayerID = _point.PlayerID;

            if (PointCoord.IsPoint(point.Y_Point, point.Y_Point) == false)
            {
                await Clients.All.SendAsync("AddPoint", point); // Отправка на frontend
                JsonConvert.SerializeObject(point); // Сериализация точки json
            }
        }
    }
}
