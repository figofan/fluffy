using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CLR.thread
{
	public class HybridLock
	{
		private int _count;
		private AutoResetEvent autoResetEvent = new AutoResetEvent(false);

		public void Enter()
		{
			if (Interlocked.Increment(ref _count) == 1)
			{
				return;
			}

			autoResetEvent.WaitOne();
		}

		public void Exit()
		{
			if (Interlocked.Decrement(ref _count) == 0)
			{
				return;
			}
			autoResetEvent.Set();
		}
	}
}
