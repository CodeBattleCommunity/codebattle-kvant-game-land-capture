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
        public async Task<IActionResult> SendMessage(Player playerIn)
        {
            EmailService emailService = new EmailService();
            string Pass = _Player.Find(playerIn => _Player.Password, playerIn).FirstOrDefault();

            await emailService.SendEmail(playerIn.Email, "CodeBattle : Пароль", 
            $"Ваш пароль : {Pass}");

            return RedirectToAction("Index");
        }
    }
}