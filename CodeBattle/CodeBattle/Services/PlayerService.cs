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
            try
            {
                _Player.InsertOneAsync(player);
                return player;
            }
            catch
            {
                return null;
            }
        }
        public List<Player> Get()
        {
            try
            {
                return _Player.Find(player => true).ToList();
            }
            catch
            {
                return null;
            }
        }

        public Player Get(int id)
        {
            try
            {
                return _Player.Find(player => player.ID == id).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public void Update(int id, Player playerIn)
        {
            try
            {
                _Player.ReplaceOneAsync(player => player.ID == id, playerIn);
            }
            catch
            {
            }
        }

        public void Remove(Player playerIn)
        {
            try
            {
                _Player.DeleteOneAsync(player => player.ID == playerIn.ID);
            }
            catch
            {

            }
        }

        public void Remove(int id)
        {
            try
            {
                _Player.DeleteOneAsync(player => player.ID == id);
            }
            catch
            {

            }
        }
    }
}
