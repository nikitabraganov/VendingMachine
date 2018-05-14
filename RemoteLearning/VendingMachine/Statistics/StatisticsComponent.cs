namespace VendingMachine.Statistics
{
    using System;
    using System.Collections.Generic;

    using VendingMachine.ContainableItem;
    using VendingMachine.Notifications;
    using VendingMachine.View;

    public class StatisticsComponent : IObserver
    {
        /// <summary>
        /// itemName, quantitySold
        /// </summary>
        private readonly Dictionary<string, int> perProductSold;
        private readonly IView view;
        private readonly DateTime startDate;
        private decimal totalAmountSold;

        public StatisticsComponent(IView view)
        {
            this.perProductSold = new Dictionary<string, int>();
            this.view = view;
            this.startDate = DateTime.Now;
        }

        public void Update(ContainableItem obj)
        {
            if (this.perProductSold.ContainsKey(obj.Name))
            {
                this.perProductSold[obj.Name]++;
            }
            else
            {
                this.perProductSold.Add(obj.Name, 1);
            }

            this.totalAmountSold += obj.Price;
        }

        public void PrintStatistics()
        {
            this.view.PrintOneLine($"Vending Machine Statistics - From: {this.startDate:G}");
            this.view.PrintOneLine("Statistics / product sold:");
            foreach (KeyValuePair<string, int> products in this.perProductSold)
            {
                this.view.PrintOneLine($"Name: {products.Key} -- Sold: {products.Value}");
            }

            this.view.PrintOneLine($"Profit: {this.totalAmountSold * 0.1m} RON");
        }
    }
}
