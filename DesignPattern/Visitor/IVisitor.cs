using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Visitor
{
	public interface IVisitor
	{
		void Visit(Loan loan);
		void Visit(Account account);
	}

	public class TotalVisitor : IVisitor
	{
		public decimal Total { get; set; }
		public void Visit(Loan loan)
		{
			Total -= loan.MonthlyPayment;
		}

		public void Visit(Account account)
		{
			Total += account.Total;
		}
	}
	public interface IAcceptable
	{
		void Accept(IVisitor visitor);
	}

	public class Loan : IAcceptable
	{
		public decimal MonthlyPayment { get; set; }
		public void Accept(IVisitor visitor)
		{
			visitor.Visit(this);
		}
	}

	public class Account : IAcceptable
	{
		public decimal Total { get; set; }
		public void Accept(IVisitor visitor)
		{
			visitor.Visit(this);
		}
	}

	public class Person : IAcceptable
	{
		public IEnumerable<IAcceptable> Acceptables { get; set; }

		public void Accept(IVisitor visitor)
		{
			foreach (var acceptable in Acceptables)
			{
				acceptable.Accept(visitor);
			}
		}
	}
}
