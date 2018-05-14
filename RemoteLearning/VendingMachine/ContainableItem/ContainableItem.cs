namespace VendingMachine.ContainableItem
{
    public class ContainableItem : Product
    {
        public ContainableItem(Product product)
        {
            this.Id = product.Id;
            this.Category = product.Category;
            this.Name = product.Name;
            this.Price = product.Price;
            this.Quantity = product.Quantity;
            this.Size = product.Size;
        }

        public Position Position { get; set; }

        public string GetDisplayInfo()
        {
            return $"Position: {this.Position.GetPosition()} - Id: {this.Id} - Name: {this.Name} - Price: {this.Price} RON - Quantity: {this.Quantity}";
        }
    }
}
