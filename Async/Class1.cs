using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    public class Class1
    {
	    public static void Main1(string[] args)
	    {
		    var task = DummyAsync();
		    task.Wait();
		    Console.ReadKey();
	    }

	    public static async Task DummyAsync()
	    {
		    var awaitable = new AWaitable();
		    var text = await awaitable;
			Console.WriteLine($"I got {text}");
	    }
	}

	class AWaitable
	{
		//public AWaiter GetAwaiter()
		//{
		//	return new AWaiter();
		//}

		public AWaiter2 GetAwaiter()
		{
			return new AWaiter2();
		}
	}

	class AWaiter : INotifyCompletion
	{
		public bool IsCompleted
		{
			get
			{
				return true;
			}
			set { value = value; }


		}

		public void OnCompleted(Action continuation)
		{
			Console.WriteLine("completed");

			Thread.Sleep(5000);
			IsCompleted = true;
		}

		public string GetResult()
		{
			return "hello";
		}
	}

	class AWaiter2 : INotifyCompletion
	{
		public bool IsCompleted
		{
			get
			{
				return true;
			}
			set { value = value; }


		}

		public void OnCompleted(Action continuation)
		{
			Console.WriteLine("completed2");

			Thread.Sleep(5000);
			IsCompleted = true;
		}

		public string GetResult()
		{
			return "hello2";
		}
	}
}
