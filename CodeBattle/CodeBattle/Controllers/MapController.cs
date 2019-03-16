using System.Collections.Generic;
using CodeBattle.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeBattle.Controllers
{
    [Route("api-v1/[controller]")]
    public class MapController : Controller
    {
        [HttpGet]
        public ActionResult<Map> Map()
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
