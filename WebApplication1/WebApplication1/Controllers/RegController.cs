using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RegController : ApiController
    {
        [HttpPost]
        public string Post(string mail, string password)
        {
            return password;
        }
        public object Post([FromBody] User customer)
        {
            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }
    }
}
