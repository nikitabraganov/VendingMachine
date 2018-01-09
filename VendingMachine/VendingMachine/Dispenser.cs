using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Dispenser : ContainableItemCollection
    {

        public Product Dispense(int id)
        {
            if (ListOfMyContainableItems.Find(r => r.ProductId == id).Quantity > 0)
            {
                --ListOfMyContainableItems.Find(r => r.ProductId == id).Quantity;
            }
            return ListOfMyContainableItems.Find(r => r.ProductId == id);
        }
    }
}
