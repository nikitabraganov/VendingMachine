using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSimpleProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal firtsAnimal = new Dog();
            Animal secondAnimal = new Cat();
            Animal thirdAnimal = new Horse();
            List<Animal> list = new List<Animal>();
            list.Add(firtsAnimal);
            list.Add(secondAnimal);
            list.Add(thirdAnimal);

            foreach (Animal a in list) {
                a.speak();
            }
            Console.ReadKey();
        }
    }
}
