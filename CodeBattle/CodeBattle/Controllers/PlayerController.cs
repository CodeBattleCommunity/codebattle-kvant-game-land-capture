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
        private ICodeBattle<Player> _PlayerService = new PlayerService();

        [HttpGet]
        public ActionResult<List<Player>> Get()
        {
            return _PlayerService.Get();
        }

        [HttpGet("{id:max(255)}")]
        public ActionResult<Player> Get(int id)
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
