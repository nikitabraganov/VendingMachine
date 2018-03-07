using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Dispenser : Observer
    {

        public Dispenser(PaymentTerminal paymentTerminal)
        {
            this.paymentTerminal = paymentTerminal;
            this.paymentTerminal.Attach(this);
        }

        public override void Update()
        {
            

        }
        //public Product Dispense(int id)
        //{
        //    if (ListOfMyContainableItems.Find(r => r.ProductId == id).Quantity > 0)
        //    {
        //        --ListOfMyContainableItems.Find(r => r.ProductId == id).Quantity;
        //    }
        //    return ListOfMyContainableItems.Find(r => r.ProductId == id);
        //}
    }
}
