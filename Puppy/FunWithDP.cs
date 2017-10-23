using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puppy
{
	public class FunWithDP
	{
		public class MineGold
		{
			public int People { get; set; }
			public int Mine { get; set; }
			public int[] Golds { get; set; }
			public int[] PeopleNeeded { get; set; }
			public int[,] MaxGolds { get; set; }

			public MineGold()
			{
				People = 101;
				Mine = 5;
				PeopleNeeded = new [] {77, 22, 29, 50, 99};
				Golds = new [] { 92, 22, 87, 46, 90};
				MaxGolds = new int[People, Mine];
				for (var i = 0; i < People; i++)
				{
					for (var j = 0; j < Mine; j++)
					{
						MaxGolds[i,j] = -1;
					}
				}
			}

			public void StartMine()
			{
				Console.WriteLine(MaxGold(People - 1, Mine - 1));;
			}

			public int MaxGold(int people, int mine)
			{
				int ret;
				if (MaxGolds[people,mine] != -1)
				{
					ret = MaxGolds[people,mine];
				}
				else if (mine == 0)
				{
					ret = people >= PeopleNeeded[mine] ? Golds[mine] : 0;
				}
				else if (people >= PeopleNeeded[mine])
				{
					// Mine or not mine current mine
					ret = Math.Max(MaxGold(people - PeopleNeeded[mine], mine - 1) + Golds[mine], 
						MaxGold(people, mine - 1));
				}
				else
				{
					ret = MaxGold(people, mine - 1);
				}

				MaxGolds[people,mine] = ret;

				return ret;
			}
		}

		public class CrossBridge
		{
			public int People { get; set; }
			public int[] TimeNeeded { get; set; }

			public CrossBridge()
			{
				People = 5;
				TimeNeeded = new[] { 1,2,4,5,6};
			}

			/// <summary>
			/// fastest = [0], faster = [1]
			/// slowest = [n-1], slower = [n-2]
			/// 
			/// proposal 1: {fastest, faster} >>  {fastest} >>  {slowest, slower} >> {faster } 
			/// time spent = [1] + [0] + [n-1] + [1]
			/// proposal 2: {fastest, slowest} >> {fastest} >> {slower, fastest} >> {fastest}
			/// time spent = [n-1] + [0] + [n-2] + [0]
			/// </summary>
			public void Start()
			{
				int total = 0;
				int people = People;
				while (people > 3)
				{
					total += Math.Min(TimeNeeded[1] + TimeNeeded[0] + TimeNeeded[people - 1] + TimeNeeded[1],

						TimeNeeded[people - 1] + TimeNeeded[0] + TimeNeeded[people - 2] + TimeNeeded[0]);

					people -= 2;
				}
				if (people == 3)
					total += TimeNeeded[1] + TimeNeeded[0] + TimeNeeded[2];
				else if (people == 2)
					total += TimeNeeded[1];
				else if (people == 1)
					total += TimeNeeded[0];

				Console.WriteLine(total);
			}
		}

		public class MaxDiff
		{
			public int[] Numbers { get; set; }
			public MaxDiff()
			{
				Numbers = new[] { 22, 2, 12, 5, 4, 7, 3, 19, 5 };
			}

			public void Calculate()
			{
				var maxNumber = Numbers.Last();
				var maxDiff = 0;
				for (var i = Numbers.Length - 2; i >= 0; i--)
				{
					if (Numbers[i] > maxNumber)
						maxNumber = Numbers[i];
					else
						maxDiff = Math.Max(maxDiff, maxNumber - Numbers[i]);
				}

				Console.WriteLine(maxDiff);
			}
		}
	}
}
