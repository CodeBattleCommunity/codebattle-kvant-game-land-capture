using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CodeBattle.PointWar.Server.Services;
using CodeBattle.PointWar.Server.Interfaces;
using CodeBattle.PointWar.Server.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Bson;

namespace CodeBattle.PointWar.Server.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmailController : Controller
    {
        private readonly IMongoCollection<Player> _Player;

        [HttpPut("{id:max(24)}")]
        public async Task<IActionResult> SendMessage(string email)
        {
            EmailService emailService = new EmailService();
            var filter = new BsonDocument("Email" , email);
            var Pass = _Player.Find<Player>(filter).FirstOrDefault();

            await emailService.SendEmail(email, "CodeBattle : Пароль", 
            $"Ваш пароль : {Pass.Password}");

            return RedirectToAction("Index");
        }
    }
}