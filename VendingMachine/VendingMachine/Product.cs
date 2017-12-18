using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Product
    {
        public int Id { get; }
        public string Name { get; }
        public float Price { get; }
        public int Size { get; }
        public ProductType Type { get; }
        public int Position { get; set; }
    }
}
