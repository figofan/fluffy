using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CLR.Tests
{
	[TestClass]
	public class ThreadPooling
	{
		[TestMethod]
		public void TestMethod1()
		{
			int workerCount, completionPortCount;
			ThreadPool.GetMaxThreads(out workerCount, out completionPortCount);

		}
	}
}
