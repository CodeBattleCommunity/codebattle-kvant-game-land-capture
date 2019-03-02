using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PlayersController : ApiController
    {
        // GET api/values
        //[Route("home")]
        [HttpGet]
        public IHttpActionResult Get2()
        {
            var user = new User()
            {
                Email = "chernikov@gmail.com",
                UserName = "rollinx",
            };
            return Json(user);
        }
    }
}
