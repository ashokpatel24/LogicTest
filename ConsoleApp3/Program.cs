using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            A objA = new A();
            objA.TestMethod();

            B objB = new B();
            objB.TestMethod();

            A objaa = new B();
            objaa.TestMethod();

        }
    }

    class A
    {
        public void TestMethod()
        {
            Console.WriteLine("from A");
            Console.ReadLine();
        }
    }

    class B:A
    {
        public new void TestMethod()
        {
            Console.WriteLine("from B");
            Console.ReadLine();
        }
    }



}
