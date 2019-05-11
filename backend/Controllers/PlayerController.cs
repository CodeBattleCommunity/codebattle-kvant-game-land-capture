using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CodeBattle.PointWar.Server.Models;
using CodeBattle.PointWar.Server.Interfaces;
using CodeBattle.PointWar.Server.Services;

namespace CodeBattle.PointWar.Server.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PlayerController : Controller
    {
        private readonly ICodeBattle<Player> _PlayerService;

        public PlayerController(ICodeBattle<Player> playerService)
        {
            this._PlayerService = playerService;
        }

        [HttpGet]
        public ActionResult<List<Player>> Get()
        {
            return _PlayerService.Get();
        }

        [HttpGet("{id:max(24)}")]
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
            player.Score = 0;
            _PlayerService.Create(player);

            return player;
        }

        [HttpPut("{id:max(24)}")]
        public IActionResult Update(int id, Player playerIn)
        {
            var player = _PlayerService.Get(id);

            if (player == null)
            {
                return NotFound();
            }

            _PlayerService.Update(id, playerIn);

            return NoContent();
        }

        [HttpDelete("{id:max(24)}")]
        public IActionResult Delete(int id)
        {
            var player = _PlayerService.Get(id);

            if (player == null)
            {
                return NotFound();
            }

            _PlayerService.Remove(player);

            return NoContent();
        }
    }

}
