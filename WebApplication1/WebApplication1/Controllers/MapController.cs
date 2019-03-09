using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class MapController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get2()
        {
            var map = new Map()
            {
                Point = new Dictionary<int, double>
                {
                    {1,0.34 },
                    {2,0.35 }
                }
                
            };
            return Json(map);
        }
    }
}
