using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesignPattern;
namespace DesignPattern.Test
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var order = new OrderFactory().CreateBy(1);
			Console.WriteLine("order created");
			Assert.IsNotNull(order);
			Assert.IsNotNull(order.Items);
			order = new Order();
		}
	}
}
