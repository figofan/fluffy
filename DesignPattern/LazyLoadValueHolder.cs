using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
	public class LazyLoadValueHolder
	{

	}

	public class Order
	{
		public int Id { get; set; }

		private ValueHolder<List<string>> _items;

		public List<string> Items => _items.Value;

		public void SetItems(ValueHolder<List<string>> items)
		{
			_items = items;
		}
	}

	public class OrderFactory
	{
		public Order CreateBy(int id)
		{
			var order= new Order();
			order.SetItems(new ValueHolder<List<string>>(new OrderValueLoader()));
			return order;
		}
	}
	public interface IValueLoader<T>
	{
		T Load();
	}

	public class ValueHolder<T>
	{
		private readonly IValueLoader<T> _loader;
		private T _value;
		public ValueHolder(IValueLoader<T> loader)
		{
			_loader = loader;
		}

		public T Value
		{
			get
			{
				if (_value == null)
					return _loader.Load();
				return _value;
			}
		}
	}


	public class OrderValueLoader : IValueLoader<List<string>>
	{
		public List<string> Load()
		{
			Console.WriteLine("initialized...");
			return new List<string>() {"a", "b"};
		}
	}

}
