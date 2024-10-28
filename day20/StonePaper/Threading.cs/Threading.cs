using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace ThreadS
{
    internal class Program
    {
        static void Action1()
        {
            Console.WriteLine("action 1 running");
            Thread.Sleep(2000);
            Console.WriteLine("action1 completed");
        }
        static void Action2()
        {
            Console.WriteLine("action 2 running");
            Thread.Sleep(2000);
            Console.WriteLine("action2 completed");
        }
        static void Main(string[] args)
        {
            var t1 = new Thread(Action1);
            var t2=new Thread(Action2);

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine("completed");
        }
    }
}
