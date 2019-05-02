using System.Collections.Generic;
using CodeBattle.PointWar.Server.Interfaces;
using CodeBattle.PointWar.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace CodeBattle.PointWar.Server.Services
{
    public class RegService : ICodeBattle<User>
    {
        private IMongoCollection<User> _User;

        public RegService([FromServices] IConfiguration config)
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

        private List<User> GetGet()
        {
            return _User.Find(player => true).ToList();
        }

        public User Get(int id)
        {
            return _User.Find(player => player.Id == id).FirstOrDefault();
        }

        public void Update(int id, User playerIn)
        {
            _User.ReplaceOne(player => player.Id == id, playerIn);
        }

        public void Remove(User playerIn)
        {
            _User.DeleteOne(player => player.Id == playerIn.Id);
        }

        public void Remove(int id)
        {
            _User.DeleteOne(player => player.Id == id);
        }

        public List<User> Get()
        {
            throw new System.NotImplementedException();
        }
    }
}