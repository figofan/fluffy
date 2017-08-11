using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.Visitor;

namespace DesignPattern
{
	class Program
	{
		static void Main(string[] args)
		{
			//SingletonMain();

			VisitMain();
			Console.WriteLine(nameof(Program.Main));
			Console.ReadKey();
		}

		static void SingletonMain()
		{
			//Singleton.DoSomething();
			Console.WriteLine("testing begins");
			var a = Singleton.Instance;
			var b = Singleton.Instance;
			Console.WriteLine("a and b are the same {0}", a == b);
			
		}

		static void VisitMain()
		{
			var person = new Visitor.Person();
			person.Acceptables = new List<IAcceptable>()
			{
				new Loan() {MonthlyPayment = 99},
				new Account() {Total = 11}
			};

			var totalVisitor = new TotalVisitor();
			person.Accept(totalVisitor);
			Console.WriteLine("total is {0}", totalVisitor.Total);
		}
	}
}
