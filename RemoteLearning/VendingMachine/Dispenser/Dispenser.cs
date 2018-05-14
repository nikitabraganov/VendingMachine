namespace VendingMachine.Dispenser
{
    using System.Collections.Generic;

    using VendingMachine.ContainableItem;
    using VendingMachine.Notifications;
    using VendingMachine.View;

    public class Dispenser : IObserver, IObservable
    {
        private readonly IView view;
        private readonly List<IObserver> observers;
        private ContainableItem item;

        public Dispenser(IView view)
        {
            this.view = view;
            this.observers = new List<IObserver>();
        }

        public void Update(ContainableItem obj)
        {
            this.view.PrintOneLine("Your product is being dispensed. Thank you!");
            this.item = obj;
            obj.Quantity -= 1; // Dispensed one product.
            this.Notify();
        }

        public void AddObserver(IObserver observer)
        {
            this.observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            this.observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (IObserver observer in this.observers)
            {
                observer.Update(this.item);
            }
        }
    }
}
