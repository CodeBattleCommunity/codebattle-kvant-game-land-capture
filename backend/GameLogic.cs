using CodeBattle.PointWar.Server.Models;
using MongoDB.Driver;

namespace CodeBattle.PointWar.Server
{
    public class GameLogic
    {
        private readonly IMongoCollection<Player> _Player;
        
        // Ситуация на карте
        public void MapSituation()
        {
            
        }
        
        // Захват точки
        public void PointСapture(int score, Player playerIn)
        {
            
            _Player.ReplaceOne(player => player.Score == score, playerIn);
        }
    }
}