using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RegController : ApiController
    {
        [HttpPost]
        public object Post([FromBody] User customer)
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
            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }
    }
}
