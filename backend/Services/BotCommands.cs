using System;
using System.Threading.Tasks;
using CodeBattle.PointWar.Server.Models;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.IO;

namespace CodeBattle.PointWar.Server.Services
{
    public class BotCommands : Hub
    {

        /// <summary>
        /// Go to Up
        /// </summary>
        public async Task Up(int x, int y, string id)
        {
            // New object
            Bot bot = new Bot(y, x, id);
            Block block = new Block();

            // Check blocks, after send "bot"
            if (block.IsBlock(bot.Y_Bot--, bot.X_Bot) == false)
            {
                // Send to clint
                await Clients.Caller.SendAsync("Up", bot.X_Bot, bot.Y_Bot--, bot.PlayerID); 
                // Send to Front - end
                await Clients.All.SendAsync("UpFront", bot.X_Bot, bot.Y_Bot--, bot.PlayerID);
                
                Console.WriteLine($"Bot ({bot.PlayerID}) - moved up ");
            }
            else
            {
                // Send to clint
                await Clients.Caller.SendAsync("Up", bot.X_Bot, bot.Y_Bot, bot.PlayerID);
                // Send to Front - end
                await Clients.All.SendAsync("UpFront", bot.X_Bot, bot.Y_Bot, bot.PlayerID); 
                
                Console.WriteLine($"Bot ({bot.PlayerID}) - could not move");
            }
        }

        /// <summary>
        /// Go to Down
        /// </summary>
        public async Task Down(int x, int y, string id)
        {
            // New object
            Bot bot = new Bot(y, x, id);
            Block block = new Block();

            // Check blocks, after send "bot"
            if (block.IsBlock(bot.Y_Bot--, bot.X_Bot) == false)
            {
                await Clients.Caller.SendAsync("Down", bot.X_Bot, bot.Y_Bot++, bot.PlayerID); // Send to clint
                await Clients.All.SendAsync("DownFront", bot.X_Bot, bot.Y_Bot++, bot.PlayerID); // Send to Front - end

                Console.WriteLine($"Bot ({bot.PlayerID}) - moved down ");
            }
            else
            {
                await Clients.Caller.SendAsync("Down", bot.X_Bot, bot.Y_Bot, bot.PlayerID); // Send to clint
                await Clients.All.SendAsync("DownFront", bot.X_Bot, bot.Y_Bot, bot.PlayerID); // Send to Front - end

                Console.WriteLine($"Bot ({bot.PlayerID}) - could not move");
            }
        }

        /// <summary>
        /// Go to left
        /// </summary>
        public async Task Left(int x, int y, string id)
        {
            // New object
            Bot bot = new Bot(y, x, id);
            Block block = new Block();

            // Check blocks, after send "bot"
            if (block.IsBlock(bot.Y_Bot--, bot.X_Bot) == false)
            {
                await Clients.Caller.SendAsync("Left", bot.X_Bot--, bot.Y_Bot, bot.PlayerID); // Send to clint
                await Clients.All.SendAsync("LeftFront", bot.X_Bot--, bot.Y_Bot, bot.PlayerID); // Send to Front - end

                Console.WriteLine($"Bot ({bot.PlayerID}) - moved left ");
            }
            else
            {
                await Clients.Caller.SendAsync("Left", bot.X_Bot, bot.Y_Bot, bot.PlayerID); // Send to clint
                await Clients.All.SendAsync("LeftFront", bot.X_Bot, bot.Y_Bot, bot.PlayerID); // Send to Front - end

                Console.WriteLine($"Bot ({bot.PlayerID}) - could not move");
            }
        }

        /// <summary>
        /// Go to Right
        /// </summary>
        public async Task Right(int x, int y, string id)
        {
            // New object
            Bot bot = new Bot(y, x, id);
            Block block = new Block();

            // Check blocks, after send "bot"
            if (block.IsBlock(bot.Y_Bot--, bot.X_Bot) == false)
            {
                await Clients.Caller.SendAsync("Right", bot.X_Bot++, bot.Y_Bot, bot.PlayerID); // Send to clint
                await Clients.All.SendAsync("RightFront", bot.X_Bot++, bot.Y_Bot, bot.PlayerID); // Send to Front - end

                Console.WriteLine($"Bot ({bot.PlayerID}) - moved lefrightt ");
            }
            else
            {
                await Clients.Caller.SendAsync("Right", bot.X_Bot, bot.Y_Bot, bot.PlayerID); // Send to clint
                await Clients.All.SendAsync("RightFront", bot.X_Bot, bot.Y_Bot, bot.PlayerID); // Send to Front - end

                Console.WriteLine($"Bot ({bot.PlayerID}) - could not move");
            }
        }

        /// <summary>
        /// Add point
        /// </summary>
        public async Task AddPoint(int x, int y, string id)
        {
            // New object
            Point point = new Point(y, x, id);
            point.Active = true;

            // Check point, after send "point"
            if (point.IsPoint(point.Y_Point, point.X_Point) == false)
            {
                // Check file
                string file = "points.json";

                if (!File.Exists(file))
                    File.Create(file);

                // Send to clint
                await Clients.Caller.SendAsync("AddPoint", point.X_Point, point.Y_Point, point.PlayerID);

                File.WriteAllText(file, JsonConvert.SerializeObject(point));

                // Send to Front-end
                await Clients.Caller.SendAsync("AddPointFront", point.X_Point, point.Y_Point, point.PlayerID);

                Console.WriteLine($"Bot ({point.PlayerID}) - add point [{point.X_Point}; {point.Y_Point}]");
            }
        }
    }
}