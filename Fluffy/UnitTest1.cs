using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IdentityModel.Tokens.Jwt;
using Puppy;
using System.Diagnostics;

namespace Fluffy
{

	[TestClass]
	public class UnitTest1
	{
        [Conditional("DEBUG")]
		[TestMethod]
		public void TestMethod1()
		{
			var jwt = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6Il9VZ3FYR190TUxkdVNKMVQ4Y2FIeFU3Y090YyIsImtpZCI6Il9VZ3FYR190TUxkdVNKMVQ4Y2FIeFU3Y090YyJ9.eyJhdWQiOiIxODdkNmFmNS1mZDlmLTRmZTItYmY4Yy1iODljZGUxYjhhMWYiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC85NTI4ZjZlMi1hZWUyLTRmZTAtYjNlYS1mOGIwYTljMGM0YWIvIiwiaWF0IjoxNDg2OTY5ODk2LCJuYmYiOjE0ODY5Njk4OTYsImV4cCI6MTQ4Njk3Mzc5NiwiYWlvIjoiQVFBQkFBRUFBQURSTllSUTNkaFJTcm0tNEstYWRwQ0pUWjFVX3QtNVN0bkdDT1dORk9Sa0xVOFphSFlsYXR4bVRSQjhLbFV5WjJNa3owZ3NldThHLVRiN20wdGRSVFZIRldzX21nbEJOM1FKOHN0QkhZVGJRVExtLWFQMjdTSzZUMXFaR0RTcXZBQXBEZmhlaFhJNTFFSGJjenFlTmFZZklBQSIsImFtciI6WyJwd2QiXSwiZmFtaWx5X25hbWUiOiJGYW4iLCJnaXZlbl9uYW1lIjoiRmlnbyIsImlwYWRkciI6IjExMy45OC42My4yNTQiLCJuYW1lIjoiRmlnbyBGYW4iLCJub25jZSI6ImQ0Njg1NjllLTA2ODctNDBhYi1hNDY2LTBlMmQ2NGUxZjIxMSIsIm9pZCI6IjUwZDQyYTk0LTkzN2UtNGY0Zi1hOWVkLWQwNzZmZTYzOWViOSIsInBsYXRmIjoiMyIsInB3ZF9leHAiOiI1MTg5MTciLCJwd2RfdXJsIjoiaHR0cHM6Ly9wb3J0YWwubWljcm9zb2Z0b25saW5lLmNvbS9DaGFuZ2VQYXNzd29yZC5hc3B4Iiwic3ViIjoiNXJhZlpCR0pDbUtoMFNRODc0UHRNNXZucjR5ampPbGlaZW9NXzRjVjYyVSIsInRpZCI6Ijk1MjhmNmUyLWFlZTItNGZlMC1iM2VhLWY4YjBhOWMwYzRhYiIsInVuaXF1ZV9uYW1lIjoiZmlnby5mYW5AQXNzdXJhbmNlRGV2ZWxvcG1lbnQub25taWNyb3NvZnQuY29tIiwidXBuIjoiZmlnby5mYW5AQXNzdXJhbmNlRGV2ZWxvcG1lbnQub25taWNyb3NvZnQuY29tIiwidmVyIjoiMS4wIn0.RLq0Hj74Ln9FpU1DTSZ0vLHEMnU7N0zMBwslSBZXH3Vuefv1Q19ZDOg_U2wORgBi9AOT5jcw-9-KtJRAOQFcIbywZA-Oh3dn-8akVxOL1Y_hAG5fIdzSi5le-9ndEcP5Oe8lQPQEr8gbUuNbfnJy-Qupm23kaJ-0a8Fk647texfSVPKs629uhG-o0G6R2Fee22m9IkEHuDqR_ifxClYKY_QQtRApdVrgh5t-tJqs_Gy8QvS1KOqSmjYBEWArQw1Tu8Q6helslZyd5pf8fCKGcjoItX5mYMle9VMlkhgYtJ3jhNMiSjgqowWRRjuj7kj7L0l3x0LBGeYpmKhFrXR7EA";
			var token = new JwtSecurityTokenHandler().ReadToken(jwt);
			Assert.IsNotNull(token);
		    Test();
            Assert.IsNotNull(null);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var jwt = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6Il9VZ3FYR190TUxkdVNKMVQ4Y2FIeFU3Y090YyIsImtpZCI6Il9VZ3FYR190TUxkdVNKMVQ4Y2FIeFU3Y090YyJ9.eyJhdWQiOiIxODdkNmFmNS1mZDlmLTRmZTItYmY4Yy1iODljZGUxYjhhMWYiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC85NTI4ZjZlMi1hZWUyLTRmZTAtYjNlYS1mOGIwYTljMGM0YWIvIiwiaWF0IjoxNDg2OTY5ODk2LCJuYmYiOjE0ODY5Njk4OTYsImV4cCI6MTQ4Njk3Mzc5NiwiYWlvIjoiQVFBQkFBRUFBQURSTllSUTNkaFJTcm0tNEstYWRwQ0pUWjFVX3QtNVN0bkdDT1dORk9Sa0xVOFphSFlsYXR4bVRSQjhLbFV5WjJNa3owZ3NldThHLVRiN20wdGRSVFZIRldzX21nbEJOM1FKOHN0QkhZVGJRVExtLWFQMjdTSzZUMXFaR0RTcXZBQXBEZmhlaFhJNTFFSGJjenFlTmFZZklBQSIsImFtciI6WyJwd2QiXSwiZmFtaWx5X25hbWUiOiJGYW4iLCJnaXZlbl9uYW1lIjoiRmlnbyIsImlwYWRkciI6IjExMy45OC42My4yNTQiLCJuYW1lIjoiRmlnbyBGYW4iLCJub25jZSI6ImQ0Njg1NjllLTA2ODctNDBhYi1hNDY2LTBlMmQ2NGUxZjIxMSIsIm9pZCI6IjUwZDQyYTk0LTkzN2UtNGY0Zi1hOWVkLWQwNzZmZTYzOWViOSIsInBsYXRmIjoiMyIsInB3ZF9leHAiOiI1MTg5MTciLCJwd2RfdXJsIjoiaHR0cHM6Ly9wb3J0YWwubWljcm9zb2Z0b25saW5lLmNvbS9DaGFuZ2VQYXNzd29yZC5hc3B4Iiwic3ViIjoiNXJhZlpCR0pDbUtoMFNRODc0UHRNNXZucjR5ampPbGlaZW9NXzRjVjYyVSIsInRpZCI6Ijk1MjhmNmUyLWFlZTItNGZlMC1iM2VhLWY4YjBhOWMwYzRhYiIsInVuaXF1ZV9uYW1lIjoiZmlnby5mYW5AQXNzdXJhbmNlRGV2ZWxvcG1lbnQub25taWNyb3NvZnQuY29tIiwidXBuIjoiZmlnby5mYW5AQXNzdXJhbmNlRGV2ZWxvcG1lbnQub25taWNyb3NvZnQuY29tIiwidmVyIjoiMS4wIn0.RLq0Hj74Ln9FpU1DTSZ0vLHEMnU7N0zMBwslSBZXH3Vuefv1Q19ZDOg_U2wORgBi9AOT5jcw-9-KtJRAOQFcIbywZA-Oh3dn-8akVxOL1Y_hAG5fIdzSi5le-9ndEcP5Oe8lQPQEr8gbUuNbfnJy-Qupm23kaJ-0a8Fk647texfSVPKs629uhG-o0G6R2Fee22m9IkEHuDqR_ifxClYKY_QQtRApdVrgh5t-tJqs_Gy8QvS1KOqSmjYBEWArQw1Tu8Q6helslZyd5pf8fCKGcjoItX5mYMle9VMlkhgYtJ3jhNMiSjgqowWRRjuj7kj7L0l3x0LBGeYpmKhFrXR7EA";
            var token = new JwtSecurityTokenHandler().ReadToken(jwt);
            Assert.IsNotNull(token);
            Test();
        }
        public static void Test()
	    {
            Console.WriteLine("Test method StackTrace: '{0}'", Environment.StackTrace);
            Test1();
        }

	    public static void Test1()
	    {
            Console.WriteLine("Test1 method StackTrace: '{0}'", Environment.StackTrace);
            Fluffy a = new Fluffy();
	        var aa = new Puppy.Puppy();
	    }

		[TestMethod]
		public void TestWriteLine()
		{
			Console.WriteLine("this is console");
			Trace.WriteLine("this is trace");
			Assert.IsNotNull(1);
		}

	}
}
