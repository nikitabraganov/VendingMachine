using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Product
    {
        public int ProductId { get; protected set; }
        public string Name { get; protected set; }
        public float Price { get; protected set; }
        public int Quantity { get; set; }
        public int Size { get; set; }
        public enum TypeOfProduct
        {
            AlcoholicDrink = 1,
            NonAlcoholicDrink = 2,
            Food = 3
        };
        public TypeOfProduct CategoriesOfAProduct { get; protected set; }
        public Product(int id, string name, float price, int size, int quantity, TypeOfProduct type)
        {
            ProductId = id;
            Name = name;
            Price = price;
            Size = size;
            CategoriesOfAProduct = type;
            Quantity = quantity;
        }
    }
}
