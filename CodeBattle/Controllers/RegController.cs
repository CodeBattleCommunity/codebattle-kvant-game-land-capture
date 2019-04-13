using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CodeBattle.Models;
using CodeBattle.Interfaces;
using CodeBattle.Services;

namespace CodeBattle.Controllers
{
    [Route("api-v1/[controller]")]
    public class RegController : Controller
    {
        private readonly ICodeBattle<User> _RegService;

        public RegController(ICodeBattle<User> userservice)
        {
            _RegService = userservice;
        }

        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return _RegService.Get();
        }

        [HttpGet("{id:max(255)}")]
        public ActionResult<User> Get(int id)
        {
            var player = _RegService.Get(id);

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
        public ActionResult<User> Create(User player)
        {
            _RegService.Create(player);

            return player;
        }

        [HttpPut("{id:max(255)}")]
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

        [HttpDelete("{id:max(255)}")]
        public IActionResult Delete(int id)
        {
            var player = _RegService.Get(id);

            if (player == null)
            {
                return NotFound();
            }

            _RegService.Remove(player.ID);

            return Ok();
        }
    }
}
