using System.Collections.Generic;
using CodeBattle.PointWar.Server.Interfaces;
using CodeBattle.PointWar.Server.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace CodeBattle.PointWar.Server.Services
{
    public class RegService : ICodeBattle<User>
    {
        private IMongoCollection<User> _User;

        public RegService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("CodeBattle"));
            var database = client.GetDatabase("CodeBattle");
            _User = database.GetCollection<User>("users");
        }

        public User Create(User player)
        {
            _User.InsertOneAsync(player);
            return player;
        }
        List<User> ICodeBattle<User>.Get()
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
