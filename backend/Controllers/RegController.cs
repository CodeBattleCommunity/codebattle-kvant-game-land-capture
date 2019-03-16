using Microsoft.AspNetCore.Mvc;

using CodeBattle.PointWar.Server.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace CodeBattle.PointWar.Server.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class RegController : Controller
    {
        [HttpPost]
        public ActionResult<User> Post([FromBody] User customer)
        {
            string connectionString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("test");
            var collection = database.GetCollection<BsonDocument>("people");
            // BsonDocument person = new BsonDocument
            // {
            // };
            BsonDocument person = customer.ToBsonDocument();
            collection.InsertOneAsync(person);
            return customer;
        }
    }
}
