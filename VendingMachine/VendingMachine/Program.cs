using System;
using System.Collections.Generic;
using System.IO;
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
            var allLines = File.ReadAllLines(@"C:\Users\Nikita\Documents\RemoteLearningIQuest\VendingMachine\VendingMachine\Objects\ProductsFromVendingMachine.txt");
            foreach (var line in allLines)
            {
                var splittedLines = line.Split(separator: ',');
                if (splittedLines != null && splittedLines.Any())
                {
                    ListOfContainableItems.AddItemToCollection(new ContainableItem(Int32.Parse(splittedLines[0]), splittedLines[1], float.Parse(splittedLines[2]), Int32.Parse(splittedLines[3]), Int32.Parse(splittedLines[4]), (Product.TypeOfProduct)Enum.Parse(typeof(Product.TypeOfProduct), splittedLines[5]), Int32.Parse(splittedLines[6]), Int32.Parse(splittedLines[7])));
                }
            }

            foreach (var a in ListOfContainableItems)
            {
                Console.Write(a.PositionInVendingMachine.Row); Console.Write(" ");
                Console.Write(a.PositionInVendingMachine.Column); Console.Write(" ");
                Console.Write(a.Name); Console.Write(" ");
                Console.Write(a.Quantity); Console.Write(" ");
                Console.Write(a.CategoriesOfAProduct); Console.Write(" ");
                Console.Write(a.ProductId); Console.Write(" ");
                Console.Write(a.Price + " lei"); Console.Write(" ");
                Console.WriteLine();
            }
            

            Console.ReadKey();
        }
    }
}
