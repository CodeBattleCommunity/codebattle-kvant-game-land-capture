using System;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Diagnostics;
using MongoDB.Driver;
using MongoDB.Bson;

namespace CodeBattle
{
    public class SignalR : Hub
    {
        // Отправка сообщений ВСЕМ клиентам
        public async Task Send(string message)
        {
            await Clients.All.SendAsync("Receive", message);
        }

        public async Task FindDB(string message)
        {
            string Connection = "mongodb://localhost";
            var Client = new MongoClient(Connection);
            var DB = Client.GetDatabase("CodeBattle");
            var Collection = DB.GetCollection<BsonDocument>("Players");
            var Filter = new BsonDocument();
            var Player = await Collection.Find(Filter).ToListAsync();
            foreach (var Count in Player)
            {
                await Clients.All.SendAsync("Send", Player);
            }
        }
    }
}
