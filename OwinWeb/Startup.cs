using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using OwinWeb;
using OwinWeb.middleware;

[assembly: OwinStartup(typeof(Startup1))]

namespace OwinWeb
{
    /// <summary>
    /// The following errors occurred while attempting to load the app.
    //- No assembly found containing an OwinStartupAttribute.
    //- No assembly found containing a Startup or[AssemblyName].Startup class.
    //To disable OWIN startup discovery, add the appSetting owin:AutomaticAppStartup with a value of "false" in your web.config.
    //To specify the OWIN startup Assembly, Class, or Method, add the appSetting owin:AppStartup with the fully qualified startup class or configuration method name in your web.config.
    /// </summary>


    public class Startup1
    {
        public static void Configuration(IAppBuilder app)
        {
            app.Use(async (ctx, next) =>
            {
                Debug.WriteLine("incoming request path: " + ctx.Request.Path);
                await next();
                Debug.WriteLine("outgoing response path: " + ctx.Request.Path);
            });

            app.UseDebugMiddleware(new DebugMiddlewareOptions()
            {
                Pre = ctx =>
                {
                    var stopwatch = new Stopwatch();
                    stopwatch.Start();
                    ctx.Environment["timer"] = stopwatch;
                },
                Post = ctx =>
                {
                    var stopwatch = (Stopwatch) ctx.Environment["timer"];
                    stopwatch.Stop();
                    Debug.WriteLine($"took {stopwatch.Elapsed} ms");
                }
            });

            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Auth/Login")

            });

            var httpConfig = new HttpConfiguration();
            httpConfig.MapHttpAttributeRoutes();
            httpConfig.Formatters.JsonFormatter.SupportedMediaTypes
                      .Add(new MediaTypeHeaderValue("text/html"));
            app.UseWebApi(httpConfig);


            //app.Use(async (ctx, next) =>
            //{
            //    await ctx.Response.WriteAsync("<h1>hello world</h1>");
            //});
        }
    }
}