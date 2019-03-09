using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RegController : ApiController
    {
        public object Post([FromBody] User customer)
        {
            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }
    }
}
