using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puppy
{
	public class FunWithArray
	{
		public static int Remove<T>(T[] array, T value)
		{
			var j = 0;
			for (var i = 0; i < array.Length; i++)
			{
				if (array[i].Equals(value)) continue;

				array[j++] = array[i];
			}
			return j;
		}

		public static int Deduplicate<T>(T[] sortedArray)
		{
			var j = 0;
			for (var i = 1; i < sortedArray.Length; i++)
			{
				if (!sortedArray[i].Equals(sortedArray[j]))
				{
					sortedArray[++j] = sortedArray[i];
				}
			}
			return j + 1;
		}

		public static void PlusN(List<int> digits, int n)
		{
			if (n < 0) return;
			var sum = digits.Last() + n;
			var left = sum % 10;
			var digit = sum / 10;
			digits[digits.Count - 1] = left;
			if (digit > 0)
			{
				for (int i = digits.Count - 2; i >= 0; i--)
				{
					sum = digits[i] + 1;
					digit = sum / 10;
					digits[i] = sum % 10;
					if (digit == 0) break;
					
				}
			}

			if (digit > 0)
				digits.Insert(0, 1);
			
		}

		public static int DeduplicateWithTolerance<T>(T[] sortedArray, int repeat)
		{
			var j = 0;
			var repeatIndex = 0;
			for (var i = 1; i < sortedArray.Length; i++)
			{
				if (!sortedArray[i].Equals(sortedArray[j]))
				{
					repeatIndex = 0;
					sortedArray[++j] = sortedArray[i];
				}
				else
				{
					repeatIndex++;
					if (repeatIndex < repeat)
					{
						sortedArray[++j] = sortedArray[i];
					}
				}
				
			}
			return j + 1;
		}

		public static List<int> PascalTriangle(int row)
		{
			var list = Enumerable.Repeat(1, row + 1).ToList();
			for (var i = 2; i <= row; i++)
			{
				for (var j = i - 1; j >= 1; j--)
				{
					list[j] = list[j] + list[j - 1];
				}
			}

			return list;
		}

		public static void MergeSortedList(List<int> list1, List<int> list2)
		{
			var list1Index = list1.Count - 1;
			var list2Index = list2.Count - 1;
			list1.AddRange(list2);//hack, expand list1's Count to get rid of outofindexrange error
			for (var i = list1.Count - 1; i >= 0; i--)
			{
				if (list1Index >= 0 && list2Index >= 0)
				{
					if (list1[list1Index] > list2[list2Index])
					{
						list1[i] = list1[list1Index];
						list1Index--;
					}
					else
					{
						list1[i] = list2[list2Index];
						list2Index--;
					}
				}
				else if (list1Index >= 0)
				{
					list1[i] = list1[list1Index];
					list1Index--;
				}
				else if (list2Index >= 0)
				{
					list1[i] = list2[list2Index];
					list2Index--;
				}
				
			}
		}

		public static int[] TwoSum(int[] array, int target)
		{
			var dict = new Dictionary<int, int>();
			for(var i = 0; i < array.Length;i++)
			{
				if (dict.ContainsKey(target - array[i]))
				{
					return new[] { dict[target - array[i]], i };
				}
				dict[array[i]] = i;
			}
			return new int[] { };
		}

		public static int MaxSubStringLength(string str)
		{
			var dict = new Dictionary<char, int>();
			var subStringLenth = 0;
			var previousOcurrenceIndex = 0;
			for (var i = 0; i < str.Length; i++)
			{
				if (dict.ContainsKey(str[i]))
				{
					previousOcurrenceIndex = Math.Max(previousOcurrenceIndex, dict[str[i]]);
				}
				
				dict[str[i]] = i;
				

				subStringLenth = Math.Max(subStringLenth, i - previousOcurrenceIndex);

			}

			return subStringLenth;
		}

		public static string LongestPalindromicSubstring(string str)
		{
			if (str.Length < 2)
				return str;
			var start = 0;
			var length = 0;

			for (var i = 0; i < str.Length; i++)
			{
				Palindromic(str, i, i, ref start, ref length);
				Palindromic(str, i, i+ 1, ref start, ref length);
			}
			return str.Substring(start, length);
		}

		private static void Palindromic(string str, int left, int right, ref int start, ref int length)
		{
			while (left >= 0 && right < str.Length && str[left] == str[right])
			{
				left--;
				right++;
			}
			if (length < right - left -1)
			{
				start = left + 1;
				length = right - left - 1;
			}
		}

		private static int HoldMostWaterClassic(int[] heights)
		{
			var max = 0;
			for (var i = 0; i < heights.Length; i++)
			{
				for (var j = i+1; j < heights.Length; j++)
				{
					max = Math.Max(max, (j - i) * Math.Min(heights[j], heights[i]));
				}
			}
			return max;
		}

		private static int HoldMostWaterOptimized(int[] heights)
		{
			var max = 0;
			var left = 0;
			var right = heights.Length -1;
			while(left < right)
			{
				max = Math.Max(max, (right - left) * Math.Min(heights[right], heights[left]));
				if (heights[left] < heights[right])
					left++;
				else
				{
					right--;
				}
			}

			return max;
		}

		private static int GetMaxAreaOfHistogram(int[] heights)
		{
			var stack = new Stack<int>();
			var i = 0;
			var maxArea = 0;
			while (i < heights.Length)
			{
				if (stack.Count == 0 || heights[i] >= heights[stack.Peek()])
				{
					stack.Push(i++);
				}
				else
				{
					var t = stack.Pop();
					maxArea = Math.Max(maxArea, heights[t] * (stack.Count == 0 ? i : (i - stack.Peek() - 1)));
				}
			}

			return maxArea;
		}

		public static bool IsIn(int[][] arr, int m)
		{
			var col = arr[0].Length;
			var row = 0;
			while (row < arr.Length && col >= 0)
			{
				if (m < arr[row][col])
					col--;
				else if (m > arr[row][col])
					row++;
				else
					return true;
			}
			return false;
		}
		#region Main
		public static void  Main2()
		{
			int[] array = {1, 2, 2, 3, 2, 4};
			var length = Remove(array, 2);
			Console.WriteLine(string.Join(", ", array.Take(length)));
		}

		public static void Main4()
		{
			int[] array = { 1, 2, 2, 2, 2,2,2,3,3, 4 };
			var length = DeduplicateWithTolerance(array, 3);
			Console.WriteLine(string.Join(", ", array.Take(length)));
		}

		public static void Main3()
		{
			int[] array = { 1, 2, 2, 2, 3, 4 };
			var length = Deduplicate(array);
			Console.WriteLine(string.Join(", ", array.Take(length)));
		}

		public static void Main5()
		{
			var list = new List<int> {9,8, 9};
			PlusN(list, 3);
			Console.WriteLine(string.Join(", ", list));
		}

		public static void Main11()
		{
			var list = PascalTriangle(5);
			Console.WriteLine(string.Join(", ", list));

		}

		public static void Main111()
		{
			var list1 = new List<int>() {1, 1, 2};
			var list2 = new List<int>() {0, 1, 1, 3, 4, 5};
			MergeSortedList(list1, list2);
			Console.WriteLine(string.Join(", ", list1));

		}

		public static void Main1111()
		{
			int[] array = { 2, 7, 12, 9};
			var a = TwoSum(array, 9);
			Console.WriteLine(string.Join(", ", 19));

		}

		public static void Main12()
		{
			var str = "pwwkew";//"abcbabcda";
			Console.WriteLine(MaxSubStringLength(str));
		}

		public static void Main1a()
		{
			var str = "pwwekkew";//"abcbabcda";
			Console.WriteLine(LongestPalindromicSubstring(str));
		}

		public static void MainZigZag()
		{
			var result = FunWithString.ParseZigzagString("PAYPALISHIRING", 1);
			Console.WriteLine(result);
		}
		#endregion

		public static void MainDFS()
		{
			var ret = new List<List<int>>() { };
			var comb = new List<int>();
			FunWithTree.DFS(ret, comb, 1, 4, 3);
			//ret = Comb(4, 2);
			foreach (var list in ret)
			{
				Console.WriteLine(string.Join(",", list));
			}
		}

		public static void Main1()
		{
			//FunWithTree.DFS();
			//Console.WriteLine(string.Join(",", FunWithTree.DFSByStack()));
			//Console.WriteLine(GetMaxAreaOfHistogram(new int[] {2, 1, 5, 6, 2, 3}));
			//FunWithTree.SumOfTree();
			Console.WriteLine(string.Join(",", FunWithTree.TraverseTreeInPostOrder()));
		}

	}
}
