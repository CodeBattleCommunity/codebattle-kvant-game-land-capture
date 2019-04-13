using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CodeBattle.Models;
using CodeBattle.Interfaces;
using CodeBattle.Services;

namespace CodeBattle.Controllers
{
    [Route("api-v1/[controller]")]
    public class PlayerController : Controller
    {
        private readonly ICodeBattle<Player> _PlayerService;

        public PlayerController(ICodeBattle<Player> playerService)
        {
            _PlayerService = playerService;
        }
        [HttpGet]
        public ActionResult<List<Player>> Get()
        {
            return _PlayerService.Get();
        }

        [HttpGet("{id:max(254)}")]
        public ActionResult<Player> Get(int id)
        {
            var player = _PlayerService.Get(id);

            if (player == null)
            {
                return NotFound();
            }
            else
            {
                return player;
            }
        }

        [HttpPost]
        public ActionResult<Player> Post(Player player)
        {
            var map_create = _PlayerService.Create(player);
            if (map_create == null)
            {
                return NoContent();
            }
            else
            {
                return player;
            }
        }

        [HttpPut("{id:max(255)}")]
        public IActionResult Update(int id, Player playerIn)
        {
            var player = _PlayerService.Get(id);

            if (player == null)
            {
                return NotFound();
            }

            _PlayerService.Update(id, playerIn);

            return Ok();
        }

        [HttpDelete("{id:max(255)}")]
        public IActionResult Delete(int id)
        {
            var player = _PlayerService.Get(id);

            if (player == null)
            {
                return NotFound();
            }

            _PlayerService.Remove(player.ID);

            return Ok();
        }
    }
}
