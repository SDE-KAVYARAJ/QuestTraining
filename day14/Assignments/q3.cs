// 3: Create an interface IAnimal with a method Speak(). Implement the interface in two classes Dog and Cat, each providing their own implementation of Speak().

//interface code

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q3
{
    internal interface IAnimal
    {
        void Speak();
    }
}


//class code
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q3
{
    internal class Program
    {
        class Dog : IAnimal
        {
            public void Speak() => Console.WriteLine("Dog makes Bow sound");
        }
        class Cat : IAnimal
        {
            public void Speak() => Console.WriteLine("Cat makes Meow sound");

        }
        static void Main(string[] args)
        {
            IAnimal dog = new Dog();
            dog.Speak();

            IAnimal cat = new Cat();
            cat.Speak();

            //Cat cat = new Cat();
            //cat.Speak();

        }
    }
}
