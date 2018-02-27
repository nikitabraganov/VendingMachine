using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Program
    {
        static void Main(string[] args)
        {
            ContainableItemCollection ListOfContainableItems = new ContainableItemCollection();
            ListOfContainableItems.LoadMyItemsToCollection();

            Console.WriteLine(ListOfContainableItems.Count());
            ListOfContainableItems.DisplayProduct();

            Console.ReadKey();
        }
    }
}
