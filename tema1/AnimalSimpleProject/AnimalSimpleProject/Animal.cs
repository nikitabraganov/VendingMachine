using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSimpleProject
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
}
