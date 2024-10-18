// 15: Write a class Animal with a virtual method MakeSound(). Create a derived class Dog that overrides MakeSound() to print "Bark!".
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q15
{
    class Animal
    {
        public virtual void MakeSound() => Console.WriteLine("Sound");
    }
    class Dog : Animal
    {
        public override void MakeSound() => Console.WriteLine("Bark");
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var animal=new Dog();
            animal.MakeSound();
        }
    }
}
