namespace CodeBattle.PointWar.Server.Models
{
  public class Block
    {
        public int X_Block { get; set; }
        public int Y_Block { get; set; }

        public bool IsBlock(int y_block, int x_block)
        {
            if (y_block == Y_Block || x_block == X_Block) return true;
            return false;
        }
    }
}
