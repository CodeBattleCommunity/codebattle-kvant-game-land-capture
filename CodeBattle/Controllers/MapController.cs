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
        private readonly MapService _MapService;

        public MapController(MapService mapService)
        {
            _MapService = mapService;
        }
        // TODO словарь некорректно(None) преобразуется в BsonElement когда отсылается в коллекцию
        [HttpPost]
        public ActionResult Post(Map map)
        {
            /*var map_create =_MapService.Create(map);
            if(map_create == null)
            {
                return NoContent();
            }
            else
            {
                return map;
            }
            */
            Console.WriteLine(map);
            return Json(map);
        }

        [HttpGet("{index:max(50)}")]
        public ActionResult<Map> Get(int index)
        {
            var map_get = _MapService.Get(index);
            if (map_get == null || index == 0)
            {
                return NoContent();
            }
            else
            {
                return map_get;
            }
        }
    }
}
