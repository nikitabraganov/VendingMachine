using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    abstract public class Observer
    {
        protected PaymentTerminal paymentTerminal;
        public abstract void Update();
    }
}
