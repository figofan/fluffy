using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern
{
	[TestClass]
	public class Liskov
	{
		[TestMethod]
		public void TestIListWithArray()
		{
			IList<string> list = new string[5];
			list.Add("abc");
		}

		[TestMethod]
		public void TestDynamicMethod()
		{
			DynamicTraceWriteLine();
		}

		private void DynamicTraceWriteLine()
		{
			var methodInfo = typeof(Trace).GetMethod("WriteLine", new Type[] {typeof(string)});
			var dynamicMethod = new DynamicMethod("WriteLine", typeof(void), new Type[] {typeof(string)});
			var il = dynamicMethod.GetILGenerator();
			il.Emit(OpCodes.Ldstr, "I'm a dynamic trace writeline");
			il.Emit(OpCodes.Call, methodInfo);
			il.Emit(OpCodes.Ret);

			var action = (Action)dynamicMethod.CreateDelegate(typeof(Action));
			action();
		}
	}
}
