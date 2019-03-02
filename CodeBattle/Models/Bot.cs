using System;
using CodeBattle.Models;

namespace CodeBattle.Models
{
    public class Bot
    {
        public int X_Bot { get; set; }
        public int Y_Bot { get; set; }

        Block BlockCoord = new Block();

        public int Up(int y_bot)
        {
            if (BlockCoord.IsBlockY(y_bot - 1) == false)
            {
                return Y_Bot--;
            }
            return Y_Bot;
        }
        public int Down(int y_bot)
        {
            if (BlockCoord.IsBlockY(y_bot + 1) == false)
            {
                return Y_Bot++;
            }
            return Y_Bot;
        }
        public int Left(int x_bot)
        {
            if (BlockCoord.IsBlockX(x_bot - 1) == false)
            {
                return X_Bot--;
            }
            return X_Bot;
        }
        public int Right(int x_bot)
        {
            if (BlockCoord.IsBlockX(x_bot + 1) == false)
            {
                return X_Bot++;
            }
            return X_Bot;
        }
    }
}
