using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLR.generic
{
	class Variance
	{
		delegate T Fun1<out T>();
		public static void Test()
		{
			var list = new List<IItem<object>>();
			list.Add(new Item<object>());
			list.Add(new Item<string>());

			IItem<object> obj = new Item<string>();

			Fun1<string> a = () => "";
			Fun1<object> fun1 = a;
		}
	}

	public interface IItem<out T>
	{
	}

	public class Item<T> : IItem<T>
	{
	}
}
