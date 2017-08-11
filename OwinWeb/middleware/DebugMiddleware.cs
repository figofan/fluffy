using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Owin;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

namespace OwinWeb.middleware
{
    public class DebugMiddleware
    {
        private readonly AppFunc _next;
        private readonly DebugMiddlewareOptions _options;
        public DebugMiddleware(AppFunc next, DebugMiddlewareOptions options)
        {
            _next = next;
            _options = options;
        }

        public async Task Invoke(IDictionary<string, object> env)
        {
            var ctx = new OwinContext(env);
            _options.Pre(ctx);
            await _next(env);
            _options.Post(ctx);
        }
    }
}