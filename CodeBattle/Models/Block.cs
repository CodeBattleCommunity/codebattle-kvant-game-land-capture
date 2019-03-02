using System;

namespace CodeBattle.Models
{
    public class Block
    {
        public int X_Block { get; set; }
        public int Y_Block { get; set; }

        public int X_Player { get; set; }
        public int Y_Player { get; set; }

        public bool IsBlockX(int x)
        {
            if (x == X_Block) return true;
            else return false;
        }
        public bool IsBlockY(int y)
        {
            if (y == Y_Block) return true;
            else return false;
        }

        public bool IsPlayerX(int x)
        {
            if (x == X_Player) return true;
            else return false;
        }
        public bool IsPlayerY(int y)
        {
            if (y == Y_Player) return true;
            else return false;
        }
    }
}
