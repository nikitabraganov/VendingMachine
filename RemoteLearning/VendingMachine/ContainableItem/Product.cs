namespace VendingMachine.ContainableItem
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        /// <summary>
        /// The number of columns occupied by the product.
        /// </summary>
        public int Size { get; set; }

        public ProductCategory Category { get; set; }
    }
}
