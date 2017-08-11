using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CLR.thread
{
	public class SpinLock
	{
		private int _count;
		public void Enter()
		{
			while (true)
			{
				if (Interlocked.CompareExchange(ref _count, 1, 0) == 0)
				break;
			}
		}

		public void Exit()
		{
			Interlocked.Decrement(ref _count);
		}
	}
}
