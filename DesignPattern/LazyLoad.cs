using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
	class LazyLoad
	{
		public LazyLoad()
		{
			// Lazy<T> is thread safe by default
			_customerInitializer = new Lazy<Customer>(() => new Customer());
		}

		private Lazy<Customer> _customerInitializer;

		public Customer Customer { get { return _customerInitializer.Value; } }
	}

	class Customer
	{
		public string Name { get; set; }
		public string Address { get; set; }
	}
}
