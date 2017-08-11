using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fluffy
{
    [TestClass]
    public class VirutalTest
    {
        [TestMethod]
        public void TestVirutalMethod()
        {
            var base1 = new Base();
            base1.Foo();
            base1.Bar();

            base1 = new Derived();
            base1.Foo();
            base1.Bar();

            var base11 = base1;
            base11.Foo();
            base11.Bar();

            //base1 = new Base();
            //base1.Foo();
            //base1.Bar();
        }

        [TestMethod]
        public void CallBarFromFoo()
        {
            Base myBase = new Derived();
            myBase.Foo();
        }

        [TestMethod]
        public void FieldRelated()
        {
            NewClass.Write("hello world");
        }
    }

    
    public class Base
    {
        public void Foo()
        {
            Debug.WriteLine("base.foo");
            Bar();
        }

        public virtual void Bar()
        {
            Debug.WriteLine("base.bar");
        }
    }

    public class Derived : Base
    {
        public new void Foo()
        {
            Debug.WriteLine("derived.foo");
        }

        public new virtual void Bar()
        {
            Debug.WriteLine("derived.bar");
        }
    }

    public class BaseClass
    {
        protected static string ConsoleWriter = "baseclass";

        public static void Write(string text)
        {
            Console.Write($"{text} from {ConsoleWriter}");
        }
    }


    public class NewClass : BaseClass
    {
        protected new static string ConsoleWriter = "new class";
    }
}
