using CodeBattle.PointWar.Server.Models;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace CodeBattle.Services
{
    public class BotCommands : Bot
    {
        /// <summary>
        /// Go to Up
        /// </summary>
        public async Task Up(Player _player, Bot _bot)
        {
            // New object
            Bot bot = new Bot();

            bot.X_Bot = _bot.X_Bot;
            bot.Y_Bot = _bot.Y_Bot;
            bot.PlayerID = _player.ID;

            // Check blocks, after send "bot"
            if (BlockCoord.IsBlock(bot.Y_Bot--, bot.X_Bot) == false)
            {
                bot.Y_Bot--;
                await Clients.Caller.SendAsync("Up", bot); // Send to clint
            }
            else
            {
                await Clients.Caller.SendAsync("Up", bot); // Send to clint
            }
        }

        /// <summary>
        /// Go to Down
        /// </summary>
        public async Task Down(Player _player, Bot _bot)
        {
            // New object
            Bot bot = new Bot();

            bot.X_Bot = _bot.X_Bot;
            bot.Y_Bot = _bot.Y_Bot;
            bot.PlayerID = _player.ID;

            // Check blocks, after send "bot"
            if (BlockCoord.IsBlock(bot.Y_Bot++, bot.X_Bot) == false)
            {
                bot.Y_Bot++;
                await Clients.Caller.SendAsync("Down", bot); // Send to clint
            }
            else
            {
                await Clients.Caller.SendAsync("Down", bot); // Send to clint
            }
        }

        /// <summary>
        /// Go to left
        /// </summary>
        public async Task Left(Player _player, Bot _bot)
        {
            // New object
            Bot bot = new Bot();

            bot.X_Bot = _bot.X_Bot;
            bot.Y_Bot = _bot.Y_Bot;
            bot.PlayerID = _player.ID;

            // Check blocks, after send "bot"
            if (BlockCoord.IsBlock(bot.Y_Bot, bot.X_Bot--) == false)
            {
                bot.X_Bot--;
                await Clients.Caller.SendAsync("Left", bot); // Send to clint
            }
            else
            {
                await Clients.Caller.SendAsync("Left", bot); // Send to clint
            }
        }

        /// <summary>
        /// Go to Right
        /// </summary>
        public async Task Right(Player _player, Bot _bot)
        {
            // New object
            Bot bot = new Bot();

            bot.X_Bot = _bot.X_Bot;
            bot.Y_Bot = _bot.Y_Bot;
            bot.PlayerID = _player.ID;

            // Check blocks, after send "bot"
            if (BlockCoord.IsBlock(bot.Y_Bot, bot.X_Bot++) == false)
            {
                bot.Y_Bot++;
                await Clients.Caller.SendAsync("Right", bot); // Send to clint
            }
            else
            {
                await Clients.Caller.SendAsync("Right", bot); // Send to clint
            }
        }

        /// <summary>
        /// Add point
        /// </summary>
        public async Task AddPoint(Point _point)
        {
            // New object
            Point point = new Point();

            point.X_Point = _point.X_Point;
            point.Y_Point = _point.Y_Point;
            point.PlayerID = _point.PlayerID;

            // Check point, after send "bot"
            if (PointCoord.IsPoint(point.Y_Point, point.Y_Point) == false)
            {
                await Clients.Caller.SendAsync("Right", bot); // Send to clint
                Point.Serialize = JsonConvert.SerializeObject(point); // Add point in JSON
            }
        }
    }
}