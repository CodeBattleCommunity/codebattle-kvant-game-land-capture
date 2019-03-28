using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CodeBattle.PointWar.Server.Models;
using CodeBattle.PointWar.Server.Services;
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

        /// <summary>
        /// Добавление точки в JSON
        /// </summary>
        [HttpPost]
        public ActionResult<Point> AddPoint(int y_p, int x_p, string _color)
        {
            Point JPoint = new Point();

            JPoint.Y_Point = y_p;
            JPoint.X_Point = x_p;
            JPoint.Color = _color;

            if(Point.IsPoint(JPoint.Y_Point, JPoint.X_Point) == false)
            {
                JPoint.AddPointJson(JPoint);
            }
        }

        // Отправка точек
        [HttpGet]
        public ActionResult<Point> GetPoint(){

        }
    }
}
