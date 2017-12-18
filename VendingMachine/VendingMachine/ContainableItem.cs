using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class ContainableItem
    {
        public List<Product> ListOfMyProducts = new List<Product>();
        public int NewPosition = 0;

        public void AddItemToCollection(Product p)
        {
            p.Position = NewPosition++;
            ListOfMyProducts.Add(p);
        }

        public void RemoveItem(Product p)
        {
            ListOfMyProducts.RemoveAll(r => (r.Position == p.Position));
        }

        public int Count()
        {
            return ListOfMyProducts.Count();
        }
        public Product GetItem(int id)
        {
            return ListOfMyProducts.Find(r => r.Id == id);
        }
    }
}
