using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class DataCollector : Observer
    {
        public DataCollector(PaymentTerminal paymentTerminal)
        {
            this.paymentTerminal = paymentTerminal;
            this.paymentTerminal.Attach(this);
        }

        public override void Update()
        {

        }
    }
}
