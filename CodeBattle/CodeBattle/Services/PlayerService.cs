using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.Extensions.Configuration;
using CodeBattle.Interfaces;

namespace CodeBattle.Models
{


    public class PlayerService : ICodeBattle<Player>
    {
        private IMongoCollection<Player> _Player;

        public PlayerService()
        {
            string connectionString = new Startup().AppConfiguration["Connection"];
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("test");
            _Player = database.GetCollection<Player>("players");
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

        public Player Get(int id)
        {
            return _Player.Find(player => player.ID == id).FirstOrDefault();
        }

        public void Update(int id, Player playerIn)
        {
            _Player.ReplaceOne(player => player.ID == id, playerIn);
        }

        public void Remove(Player playerIn)
        {
            _Player.DeleteOne(player => player.ID == playerIn.ID);
        }

        public void Remove(int id)
        {
            _Player.DeleteOne(player => player.ID == id);
        }
    }
}
