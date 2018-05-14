namespace VendingMachine.ContainableItem
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Newtonsoft.Json;

    using VendingMachine.Notifications;
    using VendingMachine.View;

    public class ContainableItemsCollection : IObserver
    {
        private readonly List<ContainableItem> products;
        private readonly VendingMachineMatrix matrix;
        private readonly IView view;

        public ContainableItemsCollection(IView view)
        {
            this.products = new List<ContainableItem>();
            this.matrix = new VendingMachineMatrix(5);
            this.view = view;
        }

        public void AddItem(ContainableItem prod)
        {
            if (this.products.Any(p => p.Id == prod.Id))
            {
                throw new Exception($"Item already exists in list with id: {prod.Id}");
            }

            this.products.Add(prod);
        }

        public List<ContainableItem> GetProducts()
        {
            return this.products;
        }

        public void PrintMatrix()
        {
            this.matrix.Print(this.view);
        }

        public void Update(ContainableItem obj)
        {
            if (obj.Quantity == 0)
            {
                // Remove it from list
                this.RemoveItem(obj.Id);

                // Clear positions in matrix.
                this.matrix.ClearPositionsInMatrix(obj.Id);
            }
        }

        public ContainableItem RemoveItem(int itemId)
        {
            ContainableItem itemToRemove = this.products.FirstOrDefault(p => p.Id == itemId);
            if (itemToRemove != null)
            {
                this.products.Remove(itemToRemove);
            }

            return itemToRemove;
        }

        public void LoadFromFile(string databaseFilePath)
        {
            using (StreamReader file = File.OpenText(databaseFilePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                var productsInFile = (List<Product>)serializer.Deserialize(file, typeof(List<Product>));
                foreach (Product product in productsInFile)
                {
                    ContainableItem item = this.BuildContainableItem(product);
                    this.AddItem(item);
                }
            }
        }

        public ContainableItem GetItem(Position position)
        {
            int id = this.matrix.GetItemIdAtPosition(position);
            ContainableItem item = this.products.FirstOrDefault(prod => prod.Id == id);
            return item;
        }

        private ContainableItem BuildContainableItem(Product product)
        {
            ContainableItem item = new ContainableItem(product);
            Position positionInMatrix = this.matrix.GetNextPosition(item.Size, item.Id);
            if (positionInMatrix != null)
            {
                item.Position = positionInMatrix;
            }
            else
            {
                throw new Exception($"Cannot add product: {item.Name} in vending machine. No position found!");
            }

            return item;
        }
    }
}
