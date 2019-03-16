using MongoDB.Driver;
using MongoDB.Bson;
using CodeBattle.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CodeBattle.Controllers
{
    [Route("api-v1/[controller]")]
    public class RegController : Controller
    {
        [HttpPost]
        public object Post([FromBody] User customer)
        {
            InsertToDataBase(customer);
            return Json(customer);
        }
        [HttpGet]
        public object Get([FromBody] User customer)
        {
            InsertToDataBase(customer);
            return Json(customer);
        }
        static async void InsertToDataBase(User user)
        {
            await Task.Run(()=>
            {
                string connectionString = "mongodb://localhost:27017";
                MongoClient client = new MongoClient(connectionString);
                IMongoDatabase database = client.GetDatabase("test");
                var collection = database.GetCollection<BsonDocument>("people");
                BsonDocument person = user.ToBsonDocument();
                collection.InsertOneAsync(person);
            });
        }
    }
}
