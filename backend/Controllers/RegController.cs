using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CodeBattle.PointWar.Server.Interfaces;
using CodeBattle.PointWar.Server.Services;
using CodeBattle.PointWar.Server.Models;

namespace CodeBattle.PointWar.Server.Controllers
{
    [Route("api/v1/[controller]")]
    public class RegController : Controller
    {
        private readonly ICodeBattle<User> _RegService;

        public RegController(ICodeBattle<User> regService)
        {
            this._RegService = regService;
        }

        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return _RegService.Get();
        }

        [HttpGet("{id:max(24)}")]
        public ActionResult<User> Get(int id)
        {
            var player = _RegService.Get(id);

            if (player == null)
            {
                return NotFound();
            }

            return player;
        }

        [HttpPost]
        public ActionResult<User> Create(User player)
        {
            _RegService.Create(player);

            return player;
        }

        [HttpPut("{id:max(24)}")]
        public IActionResult Update(int id, User playerIn)
        {
            var player = _RegService.Get(id);

            if (player == null)
            {
                return NotFound();
            }

            _RegService.Update(id, playerIn);

            return NoContent();
        }

        [HttpDelete("{id:max(24)}")]
        public IActionResult Delete(int id)
        {
            var player = _RegService.Get(id);

            if (player == null)
            {
                return NotFound();
            }

            _RegService.Remove(player);

            return NoContent();
        }
    }
}
