using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using CodeBattle.Models;
using CodeBattle.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeBattle.Controllers
{
    [Route("api-v1/[controller]")]
    public class MapController : Controller
    {
        private readonly MapService _MapService = new MapService();

        // TODO словарь некорректно(None) преобразуется в BsonElement когда отсылается в коллекцию
        [HttpPost]
        public JsonResult Post(Map map)
        {
            _MapService.Create(map);
            return Json(map);
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
