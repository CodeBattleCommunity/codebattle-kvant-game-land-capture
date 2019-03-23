using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using CodeBattle.Interfaces;

namespace CodeBattle.Models
{


    public class MapService
    {
        private IMongoCollection<Map> _Map;

        public MapService()
        {
            string connectionString = new Startup().AppConfiguration["Connection"];
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("test");
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
    }
}
