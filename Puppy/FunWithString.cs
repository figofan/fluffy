using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puppy
{
	public class FunWithString
	{
		public static string ParseZigzagString(string source, int row)
		{
			var result = string.Empty;

			var outputBuilders= new StringBuilder[row];
			for (int i = 0; i < row; i++)
			{
				outputBuilders[i] = new StringBuilder();
			}
			var index = 0;
			var increment = 0;
			for (int i = 0; i < source.Length; i++)
			{
				outputBuilders[index].Append(source[i]);
				if (index == 0) increment = 1;
				else if (index == row - 1) increment = -1;

				index += increment;
			}
			return outputBuilders.Aggregate(result, (current, outputBuilder) => current + outputBuilder.ToString());
		}
	}
}
