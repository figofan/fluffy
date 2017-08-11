using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
	public class Singleton
	{
		private static readonly Singleton SingletonInstance = new Singleton();
		private static readonly Lazy<Singleton> LazySingleton = new Lazy<Singleton>(() => new Singleton(), true);
		public static Singleton Instance => SingletonInstance;//LazySingleton.Value; //SingletonHolder.Instance;
		private Singleton()
		{
			Console.WriteLine("private Singleton ctor");
		}

		static Singleton()
		{
			Console.WriteLine("static Singleton ctor");
		}
		public static void DoSomething()
		{
			Console.WriteLine("do something");
		}

		private static class SingletonHolder
		{
			static SingletonHolder()
			{
				Console.WriteLine("static SingletonHolder ctor");
			}

			internal static readonly Singleton Instance = new Singleton();
		}


	}
}
