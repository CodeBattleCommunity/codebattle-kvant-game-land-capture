using CodeBattle.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeBattle.Controllers
{
    [Route("api-v1/[controller]")]
    [ApiController]
    public class PlayersController : Controller
    {
        [HttpGet]
        public ActionResult<User> Get2()
        {
            var user = new User()
            {
                Email = "chernikov@gmail.com",
                UserName = "rollinx",
            };
            return user;
        }
    }
}
