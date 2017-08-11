using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern
{
	[TestClass]
	public class Poc
	{
		[TestMethod]
		public void TestInjector()
		{
			var injector = new Injector();
			injector.Bind<Person, Chinese>();
			injector.Bind<Person, German>();
			injector.Bind<IAddress, Address>();
			var a = injector.Resolve<Person>();
			var b = injector.Resolve<Person>();
			
			Assert.AreNotEqual(a, b);

			var inject2 = new Injector2();
			//address has to be bound first
			inject2.Bind<IAddress, Address>();

			inject2.Bind<Person, Chinese>();

			var c = inject2.Resolve<Person>();
			var d = inject2.Resolve<Person>();
			Assert.AreSame(c, d);

			injector.BindType(typeof(Person<>), typeof(Chinese<>));

			var chineseWithString = injector.Resolve<Person<string>>();
			Assert.IsNotNull(chineseWithString);
		}
	}

	public interface Person<T>
	{
		
	}

	public class Chinese<T> : Person<T>
	{ }

	public interface Person
	{
		void Say();
	}

	public class Chinese : Person
	{
		public IAddress Address { get; set; }
		public Chinese(IAddress address)
		{
			Address = address;
			Trace.WriteLine("I'm Chinese");

		}
		public void Say()
		{
			Trace.WriteLine("I'm Chinese");
		}
	}

	public class German : Person
	{
		public IAddress Address { get; set; }
		public German(IAddress address)
		{
			Address = address;
			Trace.WriteLine("I'm German");

		}
		public void Say()
		{
			Trace.WriteLine("I'm German");
		}
	}

	public interface IAddress
	{
	}

	public class Address : IAddress
	{
		
	}
}
