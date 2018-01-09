using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class ContainableItemCollection
    {
        const int ColumnSize = 5;
        const int RowSize = 2;
        public List<ContainableItem> ListOfMyContainableItems = new List<ContainableItem>();

        public void LoadMyItemsToCollection()
        {
            var allLines = File.ReadAllLines(@"C:\Users\nic_v\Documents\remote-learning\VendingMachine\VendingMachine\Objects\ProductsFromVendingMachine.txt");
            foreach (var line in allLines)
            {
                var splittedLines = line.Split(separator: ',');
                if (splittedLines != null && splittedLines.Any())
                {
                    ListOfMyContainableItems.Add(new ContainableItem(Int32.Parse(splittedLines[0]), splittedLines[1], float.Parse(splittedLines[2]), Int32.Parse(splittedLines[3]), (Product.TypeOfProduct)Enum.Parse(typeof(Product.TypeOfProduct), splittedLines[4]), Int32.Parse(splittedLines[5]), Int32.Parse(splittedLines[6])));
                }
            }
        }
        public void AddItemToCollection(ContainableItem p)
        {
            ListOfMyContainableItems.Add(p);
        }

        public void RemoveItem(ContainableItem p)
        {
            ListOfMyContainableItems.RemoveAll(r => r.ProductId == p.ProductId);
        }

        public int Count()
        {
            return ListOfMyContainableItems.Count();
        }
        public Product GetItem(int id)
        {
            return ListOfMyContainableItems.Find(r => r.ProductId == id);
        }
        public void DisplayProduct()
        {
            foreach (var a in ListOfMyContainableItems)
            {
                Console.WriteLine(a.PositionInVendingMachine.Row);
                Console.WriteLine(a.PositionInVendingMachine.Column);
                Console.WriteLine(a.Name);
                Console.WriteLine(a.Quantity);
                Console.WriteLine(a.CategoriesOfAProduct);
                Console.WriteLine(a.ProductId);
                Console.WriteLine(a.Price + " lei");
                Console.WriteLine();
            }
        }
    }
}
