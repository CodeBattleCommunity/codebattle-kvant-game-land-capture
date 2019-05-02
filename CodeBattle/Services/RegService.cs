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
            _User.InsertOneAsync(player);
            return player;
        }
        public List<User> Get()
        {
            return _User.Find(player => true).ToList();
        }

        public User Get(int id)
        {
            return _User.Find(player => player.ID == id).FirstOrDefault();
        }

        public void Update(int id, User playerIn)
        {
            _User.ReplaceOne(player => player.ID == id, playerIn);
        }

        public void Remove(User playerIn)
        {
            _User.DeleteOne(player => player.ID == playerIn.ID);
        }

        public void Remove(int id)
        {
            _User.DeleteOne(player => player.ID == id);
        }
    }
}
