using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Owin.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OwinWeb.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            using (var server = TestServer.Create<Startup1>())
            {
                var response = await server.HttpClient.GetAsync("/");
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [TestMethod]
        public void TestPath()
        {
            var path = new Uri(new Uri("https://workorderslocal.workassureonlinedev.com/1/0/Workorders"), "https://workorderslocal11.workassureonlinedev.com/v2/Ingest/Workorders");
            Assert.IsNotNull(path);
            var funnyPath = new Uri("http://foo.bar/var/../gar");
            Assert.AreEqual(funnyPath.AbsoluteUri, "http://foo.bar/gar");
            Assert.AreEqual(funnyPath.OriginalString, "http://foo.bar/var/../gar");
        }

        [TestMethod]
        public void TestLazyLoading()
        {
            var foo = GetFoo();
            var bar = foo.Bar;
            Assert.IsNotNull(bar);
        }

        [TestMethod]
        public void TestInterpolation()
        {
            var msg = "world";
            var a = $@"{{0}}hello {msg}";

            Assert.IsNotNull(a);
        }
        public static Foo GetFoo()
        {
            var foo = new Foo();
            foo.Bar?.Count();
            foo.Bar = new List<int>() {1, 2, 3, 4}.Where(x => x % 2 == 0);
            return foo;
        }
    }

    public class Foo
    {
        public IEnumerable<int> Bar { get; set; }
    }
}
