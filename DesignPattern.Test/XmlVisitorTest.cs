using System;
using System.Diagnostics;
using DesignPattern.Visitor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern.Test
{
	[TestClass]
	public class XmlVisitorTest
	{
		[TestMethod]
		public void TestMethod1()
		{
			var xmlDoc = new XmlVisitorWrapper.XmlDoc
			{
				Parts = new XmlVisitorWrapper.XmlDocPart[]
				{
					new XmlVisitorWrapper.PlainText()
					{
						Text = "plain text"
					},
					new XmlVisitorWrapper.BoldText()
					{
						Text = "bold text"
					},

					new XmlVisitorWrapper.HyperLink()
					{
						Text = "baidu"
					}
				}
			};
			var visitor = new XmlVisitorWrapper.XmlVisitor();
			xmlDoc.Accept(visitor);
			Console.WriteLine(visitor.Text);
			Debug.WriteLine(visitor.Text);
			Assert.IsNotNull(visitor.Text);
		}
	}
}
