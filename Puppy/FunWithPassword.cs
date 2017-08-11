using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puppy
{
	class FunWithPassword
	{
		public static void Main1()
		{
			Console.WriteLine("set password:");
			var password = Console.ReadLine();
			var attempt = "";
			Console.WriteLine("Enter your password:");
			while (true)
			{
				attempt += Console.ReadKey().KeyChar;
				if (attempt.Length == password.Length) break;
			}
			Console.WriteLine("\npassword is detected to be {0} digits", attempt.Length);
			var passwordNum = Convert.ToInt64(password, 2);
			var max = (long) Math.Pow(2, password.Length) - 1;
			int found = 0;
			Parallel.For(0, max,
				() => 0,
				(p, lps, aa) =>
				{
					if (p == passwordNum)
					{
						found = (int) p;
						lps.Break();

					}
					return 0;
				},
				final =>
				{
					Console.WriteLine("tpl searching...");
				});
			Console.WriteLine("\npassword is " + ToBinary(found, password.Length));
			Console.ReadKey();
		}

		public static string ToBinary(int source, int length)
		{
			return (length > 1 ? ToBinary(source >> 1, length - 1) : null) + "01"[source & 1];
		}
	}

	 
}
