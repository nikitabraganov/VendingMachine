﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSimpleProject
{
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
}