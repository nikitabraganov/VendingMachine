using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class ContainableItem : Product
    {
        public Position PositionInVendingMachine;

        public ContainableItem(int NewId, string NewName, float NewPrice, int NewSize, int NewQuantity, TypeOfProduct NewType, int row, int column) : base(NewId, NewName, NewPrice, NewSize, NewQuantity, NewType)
        {
            PositionInVendingMachine = new Position(row, column);
        }

    }
}

