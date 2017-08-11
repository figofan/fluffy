using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLR.generic
{
	abstract class Base : IComparable
	{
		//public int CompareTo(object obj)
		//{
		//	Console.WriteLine("from derived");

		//	IComparable ic = this;
		//	return ic.CompareTo(obj);
		//}

		public abstract int CompareTo(object obj);

	}

	class Derived : Base, IComparable
	{
		//int IComparable.CompareTo(object obj)
		//{
		//	Console.WriteLine("from IComparable");
		//	return 0;
		//}

		public override int CompareTo(object obj)
		{
			Console.WriteLine("from derived");

			IComparable ic = this;
			return ic.CompareTo(obj);
		}

		//public int CompareTo(object obj)
		//{
		//	Console.WriteLine("from derived");

		//	IComparable ic = this;
		//	return ic.CompareTo(obj);
		//}
	}


	class A : IComparable
	{
		int IComparable.CompareTo(object obj)
		{
			throw new NotImplementedException();
		}

		public void Test()
		{
			
		}
	}
}
