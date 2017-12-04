using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSimpleProject
{
    abstract class Animal
    {

        public string name { get; protected set; }
        public string sound { get; protected set; }


        public void speak()
        {
            Console.WriteLine(name + " says " + sound);

        }
    }
}
