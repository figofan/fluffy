using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async
{
	public class AsyncInSync
	{
		public static void Main2(string[] args)
		{
			//Your code goes here
			Show();
		}

		public static void Show()
		{
			Task.Run(async () =>
			{
				// This async method lacks 'await' operators and will run synchronously. 
				// Consider using the 'await' operator to await non-blocking API calls, 
				// or 'await Task.Run(...)' to do CPU-bound work on a background thread
				ComputeAsync();
			});

			ComputeAsync();

			ComputeWithTask();

			Console.WriteLine("show done");
		}

		public static void Compute()
		{
			var result = 0;
			for (var i = 0; i < 10000000; i++)
			{
				result += i;
			}

			Console.WriteLine("Compute result = {0}", result);
		}

		public static async Task ComputeAsync()
		{
			var result = 0;
			for (var i = 0; i < 1000000000; i++)
			{
				result += i;
			}

			Console.WriteLine("ComputeAsync result = {0}", result);
			await Task.Delay(0);
		}

		public static void ComputeWithTask()
		{
			Task.Run(() => {
				var result = 0;
				for (var i = 0; i < 1000000000; i++)
				{
					result += i;
				}

				Console.WriteLine("ComputeWithTask result = {0}", result);
			});
		}
	}
}
