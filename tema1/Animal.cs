using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSimpleProgram
{
    class Animal
    {
        public string name = "";
        public string sound = "";


        public virtual void speak()
        {
            Console.WriteLine(name + " says " + sound);
        }

    }
    class Cat : Animal
    {


        public Cat()
        {
            name = "Cat";
            sound = "Meow";
        }
        public override void speak()
        {
            Console.WriteLine(name + " says " + sound);
        }

    }
    class Horse : Animal
    {
        public Horse()
        {
            name = "Horse";
            sound = "Pfffrt";
        }
        public override void speak()
        {
            Console.WriteLine(name + " says " + sound);
        }
    }
    class Dog : Animal
    {
        public Dog()
        {
            name = "Dog";
            sound = "Bark";
        }
        public override void speak()
        {
            Console.WriteLine(name + " says " + sound);
        }
    }

}
