using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace CodeBattle.Models
{
    public class PlayerService
    {
        private readonly IMongoCollection<Player> _Player;

        public PlayerService(IConfiguration config)
        {
            //Console.WriteLine(config.GetConnectionString("CodeBattle"));
            //string connectionString = "mongodb://localhost:27017";
            
            MongoClient client = new MongoClient(config.GetConnectionString("CodeBattle"));
            var database = client.GetDatabase("test");
            _Player = database.GetCollection<Player>("people");
        }

        public List<Player> Get()
        {
            return _Player.Find(player => true).ToList();
        }

        public Player Get(string id)
        {
            return _Player.Find(player => player.ID == id).FirstOrDefault();
        }

        public Player Create(Player player)
        {
            _Player.InsertOneAsync(player);
            return player;
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
