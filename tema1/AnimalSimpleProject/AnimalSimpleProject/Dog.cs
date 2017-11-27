using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSimpleProject
{
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
