using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;

namespace OwinWeb.middleware
{
    public class DebugMiddlewareOptions
    {
        public Action<IOwinContext> Pre { get; set; }
        public Action<IOwinContext> Post { get; set; }
    }
}