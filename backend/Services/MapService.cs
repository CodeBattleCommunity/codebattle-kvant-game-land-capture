using System.Collections.Generic;
using CodeBattle.PointWar.Server.Interfaces;
using CodeBattle.PointWar.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace CodeBattle.PointWar.Server.Services
{
    public class MapService: ICodeBattle<Map>
    {
        private IMongoCollection<Map> _Map;

        public MapService([FromServices] IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("CodeBattle"));
            var database = client.GetDatabase("CodeBattle");
            _Map = database.GetCollection<Map>("maps");
        }

        public Map Create(Map map)
        {
            _Map.InsertOneAsync(map);
            return map;
        }

        public Map Get(int index)
        {
            return _Map.Find(map => map.Index == index).FirstOrDefault();
        }

        public List<Map> Get()
        {
            throw new System.NotImplementedException();
        }

        public void Remove(Map player)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(int ID)
        {
            throw new System.NotImplementedException();
        }

        public void Update(int id, Map player)
        {
            throw new System.NotImplementedException();
        }
    }
}
