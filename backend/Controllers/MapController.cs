using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using CodeBattle.PointWar.Server.Models;

namespace CodeBattle.PointWar.Server.Controllers
{
    public class MapController : Controller
    {
        [HttpGet]
        public ActionResult<Map> Get2()
        {
            var map = new Map()
            {
                Height = 640,
                Width = 480,
                Index = 1,
                Point = new Dictionary<int, double>
                {
                    {1,0.34 },
                    {2,0.35 }
                }
                
            };
            return map;
        }
    }
}
