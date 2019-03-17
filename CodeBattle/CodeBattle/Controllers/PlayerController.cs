using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CodeBattle.Models;

namespace CodeBattle.Controllers
{
    [Route("api-v1/[controller]")]
    public class PlayerController : Controller
    {
        private readonly PlayerService _PlayerService = new PlayerService();

        public PlayerController(PlayerService playerService)
        {
            _PlayerService = playerService;
        }

        [HttpGet]
        public ActionResult<List<Player>> Get()
        {
            return _PlayerService.Get();
        }

        [HttpGet("{id:max(255)}", Name = "GetPlayer")]
        public ActionResult<Player> Get(string id)
        {
            var player = _PlayerService.Get(id);

            if (player == null)
            {
                return NotFound();
            }

            return player;
        }

        [HttpPost]
        public ActionResult<Player> Create(Player player)
        {
            _PlayerService.Create(player);

            return player;
        }

        [HttpPut("{id:max(255)}")]
        public IActionResult Update(string id, Player playerIn)
        {
            var player = _PlayerService.Get(id);

            if (player == null)
            {
                return NotFound();
            }

            _PlayerService.Update(id, playerIn);

            return NoContent();
        }

        [HttpDelete("{id:max(255)}")]
        public IActionResult Delete(string id)
        {
            var player = _PlayerService.Get(id);

            if (player == null)
            {
                return NotFound();
            }

            _PlayerService.Remove(player.ID);

            return NoContent();
        }
    }
}
