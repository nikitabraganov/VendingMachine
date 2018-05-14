using System;
using System.Collections.Generic;

namespace Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            var animals = new List<Animal>
            {
                new Cat(),
                new Dog()
            };

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.GeneralInfo());
            }
        }
    }
}
