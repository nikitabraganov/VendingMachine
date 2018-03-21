using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class ContainableItemCollection : IEnumerable<ContainableItem>
    {
        const int ColumnSize = 5;
        const int RowSize = 2;
        public List<ContainableItem> ListOfMyContainableItems = new List<ContainableItem>();

        public IEnumerator<ContainableItem> GetEnumerator()
        {
            return ListOfMyContainableItems.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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
    }
}
