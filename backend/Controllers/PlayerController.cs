using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CodeBattle.PointWar.Server.Models;

namespace CodeBattle.PointWar.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : Controller
    {
        private readonly PlayerService _PlayerService;

        public PlayerController(PlayerService playerService)
        {
            _PlayerService = playerService;
        }

        [HttpGet]
        public ActionResult<List<Player>> Get()
        {
            return _PlayerService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetPlayer")]
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

            return CreatedAtRoute("GetPlayer", new { id = player.ID.ToString() }, player);
        }

        [HttpPut("{id:length(24)}")]
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

        [HttpDelete("{id:length(24)}")]
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
