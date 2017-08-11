using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Visitor
{
	public class XmlVisitorWrapper
	{
		public interface IVisitor
		{
			void Visit(PlainText plainText);
			void Visit(BoldText boldText);
			void Visit(HyperLink hyperLink);

			void Visit(dynamic xmlPart);
			//void Visit(object xmlPart);

		}

		public class XmlVisitor : IVisitor
		{
			public string Text { get; set; }
			public void Visit(PlainText plainText)
			{
				Text += plainText.Text;
			}

			public void Visit(BoldText boldText)
			{
				Text += $"<b>{boldText.Text}</b>";
			}

			public void Visit(HyperLink hyperLink)
			{
				Text += $"<a>{hyperLink.Text}</a>";
			}

			public void Visit(dynamic xmlPart)
			{
				Visit(xmlPart);
			}

			///
			/// won't work since it's recursive
			//public void Visit(object xmlPart)
			//{
			//	Visit(xmlPart);
			//}
		}

		public interface IVisitable
		{
			void Accept(IVisitor visitor);
		}

		public abstract class XmlDocPart : IVisitable
		{
			public string Text { get; set; }
			public virtual void Accept(IVisitor visitor)
			{
				visitor.Visit(this);
			}
		}

		public class PlainText : XmlDocPart
		{
			public override void Accept(IVisitor visitor)
			{
				visitor.Visit(this);
			}
		}

		public class BoldText : XmlDocPart
		{
			
		}

		public class HyperLink : XmlDocPart
		{
			
		}

		public class XmlDoc : IVisitable
		{
			public IEnumerable<XmlDocPart> Parts { get; set; }

			public void Accept(IVisitor visitor)
			{
				foreach (var xmlDocPart in Parts)
				{
					xmlDocPart.Accept(visitor);
				}
			}
		}



	}
}
