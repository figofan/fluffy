using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;

namespace OwinWeb.middleware
{
    public static class OwinExtensions
    {
        public static void UseDebugMiddleware(this IAppBuilder app, DebugMiddlewareOptions options)
        {
            app.Use<DebugMiddleware>(options);
        }
    }
}