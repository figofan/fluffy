using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puppy
{
	public class FunWithTree
	{
		private static readonly Node root = new Node()
		{
			Value = 0,
			Left = new Node()
			{
				Value = 1,
				Left = new Node()
				{
					Value = 3,
					Left = new Node()
					{
						Value = 4
					}
				}
			},
			Right = new Node()
			{
				Value = 2,
				Left = new Node()
				{
					Value = 5,
					Right = new Node()
					{
						Value = 6
					}

				}
			}
		};
		public static void DFS(List<List<int>> ret, List<int> combination, int level, int n, int k)
		{
			if (combination.Count == k)
			{
				//Console.WriteLine("return：" + string.Join(",", combination));
				ret.Add(new List<int>(combination));
				return;
			}

			//Console.WriteLine("before：" + string.Join(",", combination));
			for (var i = level; i <= n; i++)
			{
				combination.Add(i);
				DFS(ret, combination, i + 1, n, k);
				combination.Remove(combination.Last());
				//Console.WriteLine("level:" + level + " after:" + string.Join(",", combination));
			}
		}

		public static void BFS()
		{
			var root = new Node()
			{
				Value = 0,
				Left = new Node()
				{
					Value = 1,
					Left = new Node()
					{
						Value = 3,
						Left = new Node()
						{
							Value = 4
						}
					}
				},
				Right = new Node()
				{
					Value = 2,
					Left = new Node()
					{
						Value = 5,
						Right = new Node()
						{
							Value = 6
						}

					}
				}
			};

			var queue = new Queue<Node>();
			queue.Enqueue(root);
			while (queue.Count > 0)
			{
				var node = queue.Dequeue();
				if (node.Left != null)
				{
					queue.Enqueue(node.Left);
				}
				if (node.Right != null)
				{
					queue.Enqueue(node.Right);
				}
				Console.Write("{0},", node.Value);
			}
		}

		public static void DFS()
		{
			var root = new Node()
			{
				Value = 0,
				Left = new Node()
				{
					Value = 1,
					Left = new Node()
					{
						Value = 3,
						Left = new Node()
						{
							Value = 4
						}
					}
				},
				Right = new Node()
				{
					Value = 2,
					Left = new Node()
					{
						Value = 5,
						Right = new Node()
						{
							Value = 6
						}

					}
				}
			};

			//var stack = new Stack<Node>();
			//stack.Push(root);
			//while (stack.Count > 0)
			//{
				
			//}
			DFSInternal(root);
		}

		private static void DFSInternal(Node node)
		{
			Console.Write("{0},", node.Value);
			if (node.Left != null)
			{
				DFSInternal(node.Left);
			}

			if (node.Right != null)
			{
				DFSInternal(node.Right);
			}
		}

		public static IEnumerable<int> InOrder()
		{
			var root1 = new Node()
			{
				Value = 0,
				Left = new Node()
				{
					Value = 1,
					Left = new Node()
					{
						Value = 3,
						Left = new Node()
						{
							Value = 4
						}
					}
				},
				Right = new Node()
				{
					Value = 2,
					Left = new Node()
					{
						Value = 5,
						Right = new Node()
						{
							Value = 6
						}

					}
				}
			};
			var root = root1;
			var stack = new Stack<Node>();
			while (stack.Count != 0 || root != null)
			{
				while (root != null)
				{
					stack.Push(root);
					root = root.Left;
				}
				root = stack.Pop();
				yield return root.Value;
				root = root.Right;

				if (stack.Count == 0 && root == null)
					break;
			}
		}

		public static IEnumerable<int> DFSByStack()
		{
			

			var stack = new Stack<Node>();
			stack.Push(root);
			while (stack.Count > 0)
			{
				var node = stack.Pop();
				yield return node.Value;
				if (node.Right != null)
					stack.Push(node.Right);
				if (node.Left != null)
					stack.Push(node.Left);
			}
		}

		public static bool IsSameTree(Node leftTree, Node rightTree)
		{
			if (leftTree == null && rightTree == null) return true;
			if (leftTree == null || rightTree == null) return false;
			return leftTree.Value == rightTree.Value
			       && IsSameTree(leftTree.Left, rightTree.Right)
			       && IsSameTree(leftTree.Right, rightTree.Right);
		}

		public static void SumOfTree()
		{
			int sum = 0;
			var root = new Node()
			{
				Value = 1,
				Left = new Node()
				{
					Value = 2
				},
				Right = new Node()
				{
					Value = 3,
					Left = new Node()
					{
					Value = 4
					},
					Right = new Node()
					{
						Value = 5
					}
				}
			};

			DFS(root, new List<int>(), ref sum);
			Console.WriteLine(sum);
		}

		public static void DFS(Node node, List<int> list, ref int sum)
		{
			if (node == null) return;

			list.Add(node.Value);

			if (node.Left == null && node.Right == null)
			{
				sum += Sum(list);
				
			}

			if (node.Left != null)
				DFS(node.Left, list, ref sum);
			if (node.Right != null)
				DFS(node.Right, list, ref sum);
			list.RemoveAt(list.Count - 1);
		}

		public static int Sum(List<int> stack)
		{
			return stack.Aggregate(0, (current, s) => current * 10 + s);
		}

		public class  Node
		{
			public int Value { get; set; }
			public Node Left { get; set; }
			public Node Right { get; set; }
		}
	}
}
