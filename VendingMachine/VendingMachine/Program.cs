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
            ContainableItem containableItem = new ContainableItem();
            List<Product> myListOfProducts = new List<Product>();
            myListOfProducts.Add(new Product());

            containableItem.AddItemToCollection(myListOfProducts[0]);
            Console.WriteLine(containableItem.Count());
            Console.WriteLine(containableItem.ListOfMyProducts[0].Position);

            Console.ReadKey();
        }
    }
}
