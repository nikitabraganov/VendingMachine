using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSimpleProject
{
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
}
