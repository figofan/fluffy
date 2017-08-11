using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace OwinSelftHostSample
{
	class Program
	{
		static void Main()
		{
			string baseAddress = "http://localhost:9000/";

			// Start OWIN host 
			using (WebApp.Start<Startup>(url: baseAddress))
			{
				// Create HttpCient and make a request to api/values 
				Console.WriteLine("service is up");
				Console.ReadLine();
			}

			//var app = WebApp.Start<Startup>(url: baseAddress);
			//Task.Delay(100000);
			//Thread.Sleep(10000);
			Console.ReadKey();
            //app.Dispose();
		}
	}
}
