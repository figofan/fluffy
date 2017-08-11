using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puppy
{
	public class Program
	{
		public static void Main(string[] args)
		{
			//FunWithPassword.Main1();
			FunWithArray.Main1();

			Console.ReadKey();
		}

		public static void Main1(string[] args)
		{
			//Your code goes here
			var a = GetList();
			Console.WriteLine(a.Count());
			Console.WriteLine(a.Count());
			Console.WriteLine(Guid.NewGuid());
			Console.ReadKey();
		}

		public static IEnumerable<string> GetList()
		{
			Console.WriteLine(Environment.StackTrace);
			yield return "a";
		}
	}
}
