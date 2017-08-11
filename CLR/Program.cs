using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLR.caller;
using CLR.generic;

namespace CLR
{
    class Program
    {
		static void Main(string[] args)
		{
			//Main1(args);
			//Main2(args);

			//var derived = new Derived();
			//derived.CompareTo(new Derived());
			var path = @"D:\workspace\ms.plugins";
			var total = TaskDelegates.GetDirBytes(path, "*.cs", SearchOption.AllDirectories);
			Console.WriteLine("total is " + total);

			Console.WriteLine("===========================");
			var asyncTotla = TaskDelegates.GetDirBytesAsync(path, "*.cs", SearchOption.AllDirectories);
			Console.WriteLine("async total is " + asyncTotla);
			Console.ReadKey();
		}
		static void Main1(string[] args)
        {
            var point = new Point();
            Console.WriteLine(point);
            point.Change(1,1);
            Console.WriteLine(point);

            object obj = point;
            ((Point)obj).Change(2,2);
            Console.WriteLine(point);

            ((IChangable) point).Change(3,3);
            Console.WriteLine(point);

            ((IChangable)obj).Change(4, 4);
            Console.WriteLine(obj);
            Console.ReadKey();
        }

	    static void Main2(string[] args)
	    {
			var callerInfo = new CallerInfoAttributeDemo();
			Console.WriteLine(callerInfo.WhoCalledMe());
			Console.WriteLine(callerInfo.WhatFileCalledMe());
			Console.WriteLine(callerInfo.WhatLineCalledMe());

			//Don't do this
			Console.WriteLine(callerInfo.WhatLineCalledMe(111));
		}

	}
}
