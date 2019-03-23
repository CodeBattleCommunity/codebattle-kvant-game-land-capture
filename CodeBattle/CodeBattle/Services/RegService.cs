using CodeBattle.Interfaces;
using CodeBattle.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeBattle.Services
{
    public class RegService : ICodeBattle<User>
    {
        private IMongoCollection<User> _User;

        public RegService()
        {
            string connectionString = new Startup().AppConfiguration["Connection"];
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("test");
            _User = database.GetCollection<User>("users");
        }

        public User Create(User player)
        {
            try
            {
                _User.InsertOneAsync(player);
                return player;
            }
            catch
            {
                return null;
            }
        }
        public List<User> Get()
        {
            return _User.Find(player => true).ToList();
        }

        public User Get(int id)
        {
            try
            {
                return _User.Find(player => player.ID == id).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public void Update(int id, User playerIn)
        {
            try
            {
                _User.ReplaceOneAsync(player => player.ID == id, playerIn);
            }
            catch
            {
            }
        }

        public void Remove(User playerIn)
        {
            try
            {
                _User.DeleteOneAsync(player => player.ID == playerIn.ID);
            }
            catch
            {
            }
        }

        public void Remove(int id)
        {
            try
            {
                _User.DeleteOne(player => player.ID == id);
            }
            catch
            {
            }
        }
    }
}
