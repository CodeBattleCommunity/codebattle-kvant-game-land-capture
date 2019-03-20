using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace CodeBattle.PointWar.Server.Models
{
    public class PlayerService
    {
        private readonly IMongoCollection<Player> _Player;

        public PlayerService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("CodeBattle"));
            var database = client.GetDatabase("CodeBattle");
            _Player = database.GetCollection<Player>("Player");
        }

        // Вывод списка игроков
        public List<Player> Get()
        {
            return _Player.Find(player => true).ToList();
        }

        // Вывод одного игрока
        public Player Get(string id)
        {
            return _Player.Find<Player>(player => player.ID == id).FirstOrDefault();
        }

        // Регистрация пользователя
        public Player Create(Player player)
        {
            _Player.InsertOne(player);
            return player;
        }
        
        // Изменение пользователя
        public void Update(string id, Player playerIn)
        {
            _Player.ReplaceOne(player => player.ID == id, playerIn);
        }

        // Удаление пользователя
        public void Remove(Player playerIn)
        {
            _Player.DeleteOne(player => player.ID == playerIn.ID);
        }

        // Удаление пользователя
        public void Remove(string id)
        {
            _Player.DeleteOne(player => player.ID == id);
        }
    }
}
