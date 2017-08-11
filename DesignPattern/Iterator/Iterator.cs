using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Iterator
{
	namespace Iterator
	{
		public class FakeList
		{
			public IEnumerator<int> GetEnumerator()
			{
				return new MyEnumerator(new List<int> { 1, 3 });
			}
		}

		public class MyEnumerator : IEnumerator<int>
		{
			List<int> _list;
			int position = -1;
			public MyEnumerator(List<int> list)
			{
				_list = list;
			}

			public int Current => _list[position];

			object IEnumerator.Current => _list[position];

			public bool MoveNext()
			{
				if (position == _list.Count - 1)
					return false;
				position++;
				return true;
			}

			public void Reset()
			{
				position = -1;
			}

			public void Dispose()
			{
			}
		}
	}
}
