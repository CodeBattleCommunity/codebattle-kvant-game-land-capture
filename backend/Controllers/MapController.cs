using Microsoft.AspNetCore.Mvc;
using CodeBattle.PointWar.Server.Models;
using CodeBattle.PointWar.Server.Interfaces;

namespace CodeBattle.PointWar.Server.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MapController : Controller
    {
        private readonly ICodeBattle<Map> _MapService;

        public MapController(ICodeBattle<Map> mapService)
        {
            this._MapService = mapService;
        }

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
