using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using CodeBattle.Models;
using CodeBattle.Services;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace CodeBattle.Controllers
{
    [Route("api-v1/[controller]")]
    public class MapController : Controller
    {
        private readonly MapService _MapService = new MapService();

        [HttpPost]
        public IActionResult CreateAction([FromBody]Map model)
        {
            _MapService.Create(model);
            return Json(model);
        }

        [HttpGet("{index:max(50)}")]
        public ActionResult<Map> Get(int index)
        {
            if (index == 0)
            {
                return NoContent();
            }
            return _MapService.Get(index);
        }
    }
}
