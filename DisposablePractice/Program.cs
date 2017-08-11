using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposablePractice
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("'g' to get date; 'gc' to garbage collect; 'x' to exit");
			var command = string.Empty;
			while (command != "x")
			{
				command = Console.ReadLine();
				switch (command)
				{
					case "g":
						GetDate();
						break;
					case "gc":
						GC.Collect();
						Console.WriteLine("gc finished!");
						break;
				}
			}
		}

		//private static DbContext ctx;
		private static void GetDate()
		{
			//for (var i = 0; i < 1000; i++)
			{
				var ctx = new UnmanagedDbContext();
				//if (ctx == null)
				//	ctx = new DbContext();

				//using (

				//)
				Console.WriteLine($"{0} - {ctx.GetDate()}");
			}
		}
	}
}
