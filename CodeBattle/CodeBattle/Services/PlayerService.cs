using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.Extensions.Configuration;

namespace CodeBattle.Models
{
   

    public class PlayerService
    {
        private IMongoCollection<Player> _Player;

        public PlayerService()
        {
            string connectionString = new Startup().AppConfiguration["Connection"];
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("test");
            _Player = database.GetCollection<Player>("player");
        }

        public Player Create(Player player)
        {
            _Player.InsertOneAsync(player);
            return player;
        }
        public List<Player> Get()
        {
            return _Player.Find(player => true).ToList();
        }

        public Player Get(string id)
        {
            return _Player.Find(player => player.ID == id).FirstOrDefault();
        }

        public void Update(string id, Player playerIn)
        {
            _Player.ReplaceOne(player => player.ID == id, playerIn);
        }

        public void Remove(Player playerIn)
        {
            _Player.DeleteOne(player => player.ID == playerIn.ID);
        }

        public void Remove(string id)
        {
            _Player.DeleteOne(player => player.ID == id);
        }
    }
}
