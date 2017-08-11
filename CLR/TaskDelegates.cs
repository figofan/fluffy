using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CLR
{
	public class TaskDelegates
	{

		public static long GetDirBytesAsync(string path, string searchPattern, SearchOption searchOption)
		{
			long total = 0;

			var files = Directory.EnumerateFiles(path, searchPattern, searchOption);
			var stopWatch = Stopwatch.StartNew();
			Parallel.ForEach<string, long>(
				files,
				() =>
				{
					Console.WriteLine("task init");
					return 0L;
				},
				(file, loopState, index, taskLocalTotal) =>
				{
					long fileLength = 0;
					try
					{
						using (var fs = File.OpenRead(file))
						{
							fileLength = fs.Length;
						}
					}
					catch (Exception e)
					{
						Console.WriteLine(e);
						throw;
					}
					var ttl = fileLength + taskLocalTotal;
					Console.WriteLine($"executing file {file} length {fileLength} total {taskLocalTotal}");
					return ttl;
				},
				taskLocalTotal =>
				{
					Console.WriteLine("sum up " + taskLocalTotal);
					Interlocked.Add(ref total, taskLocalTotal);
				}
				);
			stopWatch.Stop();
			Console.WriteLine("time spent {0}", stopWatch.Elapsed);
			return total;
		}

		public static long GetDirBytes(string path, string searchPattern, SearchOption searchOption)
		{
			long total = 0;

			var files = Directory.EnumerateFiles(path, searchPattern, searchOption);
			var stopWatch = Stopwatch.StartNew();
			foreach (var file in files)
			{
				long fileLength = 0;
				try
				{
					using (var fs = File.OpenRead(file))
					{
						fileLength = fs.Length;
						total += fileLength;
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
					throw;
				}
				Console.WriteLine($"executing file {file} length {fileLength} total {total}");
			}
			
			stopWatch.Stop();
			Console.WriteLine("time spent {0}", stopWatch.Elapsed);
			return total;
		}
	}
}
