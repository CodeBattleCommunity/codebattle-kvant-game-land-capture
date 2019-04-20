using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using CodeBattle.Interfaces;
using Microsoft.Extensions.Options;
using CodeBattle.Models;

namespace CodeBattle.Services
{
    public class MapService
    {
        private IMongoCollection<Map> _Map;

        public MapService(IOptions<_Options> config)
        {
            MongoClient client = new MongoClient(config.Value.Connection_str);
            IMongoDatabase database = client.GetDatabase("test");
            _Map = database.GetCollection<Map>("maps");
        }

        public Map Create(Map map)
        {
            try
            {
                _Map.InsertOneAsync(map);
                return map;
            }
            catch
            {
                return null;
            }
        }

        public Map Get(int index)
        {
            try
            {
                return _Map.Find(map => map.Index == index).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }
    }
}
