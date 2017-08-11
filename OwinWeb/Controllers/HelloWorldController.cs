using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace OwinWeb.Controllers
{
    [RoutePrefix("api")]
    public class HelloWorldController : ApiController
    {
        [Route("hello")]
        [HttpGet]
        public IHttpActionResult HelloWorld()
        {
            return Content(HttpStatusCode.OK, "hello world from web api");
        }
    }
}