using System;
using CodeBattle.Models;

namespace CodeBattle.Models
{
    public class Bot
    {
        public int X_Bot { get; set; }
        public int Y_Bot { get; set; }

        Block BlockCoord = new Block();

        public int Up(int y)
        {
            if (Y_Bot - 1 != BlockCoord.Y_Block || Y_Bot - 1 != 0)
            {
                return Y_Bot--;
            }
            return Y_Bot;
        }
        public int Down(int y)
        {
            if (Y_Bot + 1 != BlockCoord.Y_Block)
            {
                return Y_Bot++;
            }
            return Y_Bot;
        }
        public int Left(int x)
        {
            if (X_Bot - 1 != BlockCoord.X_Block || X_Bot - 1 != 0)
            {
                return X_Bot--;
            }
            return X_Bot;
        }
        public int Right(int x)
        {
            if (X_Bot + 1 != BlockCoord.X_Block)
            {
                return X_Bot++;
            }
            return X_Bot;
        }
    }
}
