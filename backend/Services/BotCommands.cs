using System;
using System.Threading.Tasks;
using CodeBattle.PointWar.Server.Models;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace CodeBattle.PointWar.Server.Services
{
    public class BotCommands : Hub
    {

        /// <summary>
        /// Go to Up
        /// </summary>
        public async Task Up(Player _player, Bot _bot)
        {
            // New object
            Bot bot = new Bot(_bot.Y_Bot, _bot.X_Bot, _player.ID);
            Block block = new Block();

            // Check blocks, after send "bot"
            if (block.IsBlock(bot.Y_Bot--, bot.X_Bot) == false)
            {
                bot.Y_Bot--;
                await Clients.All.SendAsync("UpFront", bot); // Send to Front - end
                await Clients.Caller.SendAsync("Up", bot); // Send to clint
                
                Console.WriteLine($"Bot ({bot.PlayerID}) - moved up ");
            }
            else
            {
                await Clients.All.SendAsync("UpFront", bot); // Send to Front - end
                await Clients.Caller.SendAsync("Up", bot); // Send to clint
                
               Console.WriteLine($"Bot ({bot.PlayerID}) - could not move");
            }
        }

        /// <summary>
        /// Go to Down
        /// </summary>
        public async Task Down(Player _player, Bot _bot)
        {
            // New object
            Bot bot = new Bot(_bot.Y_Bot, _bot.X_Bot, _player.ID);
            Block block = new Block();

            // Check blocks, after send "bot"
            if (block.IsBlock(bot.Y_Bot++, bot.X_Bot) == false)
            {
                bot.Y_Bot++;
                await Clients.All.SendAsync("DownFront", bot); // Send to Front - end
                await Clients.Caller.SendAsync("Down", bot); // Send to clint
                
            }
            else
            {
                await Clients.All.SendAsync("DownFront", bot); // Send to Front - end
                await Clients.Caller.SendAsync("Down", bot); // Send to clint
                
                Console.WriteLine($"Bot ({bot.PlayerID}) - could not move");
            }
        }

        /// <summary>
        /// Go to left
        /// </summary>
        public async Task Left(Player _player, Bot _bot)
        {
            // New object
            Bot bot = new Bot(_bot.Y_Bot, _bot.X_Bot, _player.ID);
            Block block = new Block();

            // Check blocks, after send "bot"
            if (block.IsBlock(bot.Y_Bot, bot.X_Bot--) == false)
            {
                bot.X_Bot--;
                await Clients.All.SendAsync("LeftFront", bot); // Send to Front-end
                await Clients.Caller.SendAsync("Left", bot); // Send to clint
            }
            else
            {
                await Clients.All.SendAsync("LeftFront", bot); // Send to Front-end
                await Clients.Caller.SendAsync("Left", bot); // Send to clint
                
                Console.WriteLine($"Bot ({bot.PlayerID}) - could not move");
            }
        }

        /// <summary>
        /// Go to Right
        /// </summary>
        public async Task Right(Player _player, Bot _bot)
        {
            // New object
            Bot bot = new Bot(_bot.Y_Bot, _bot.X_Bot, _player.ID);
            Block block = new Block();

            // Check blocks, after send "bot"
            if (block.IsBlock(bot.Y_Bot, bot.X_Bot++) == false)
            {
                bot.Y_Bot++;
                await Clients.All.SendAsync("RightFront", bot); // Send to Front-end
                await Clients.Caller.SendAsync("Right", bot); // Send to clint
            }
            else
            {
                await Clients.All.SendAsync("RightFront", bot); // Send to Front-end
                await Clients.Caller.SendAsync("Right", bot); // Send to clint
                
                Console.WriteLine($"Bot ({bot.PlayerID}) - could not move");
            }
        }

        /// <summary>
        /// Add point
        /// </summary>
        public async Task AddPoint(Point _point)
        {
            // New object
            Point point = new Point(_point.Y_Point, _point.X_Point);
            point.PlayerID = _point.PlayerID;

            // Check point, after send "point"
            if (point.IsPoint(point.Y_Point, point.Y_Point) == false)
            {
                // Send to clint
                await Clients.Caller.SendAsync("AddPoint", JsonConvert.SerializeObject(point));
                // Send to Front-end
                await Clients.Caller.SendAsync("AddPointFront", JsonConvert.SerializeObject(point));
            }
        }
    }
}