namespace VendingMachine.Payment
{
    using System.Collections.Generic;

    using VendingMachine.ContainableItem;
    using VendingMachine.Notifications;

    public class PaymentTerminal : IObservable
    {
        private readonly List<IObserver> observers;
        private ContainableItem currentItem;
        private decimal currentAmount;
        private decimal amountToPay;
        private decimal changeToReturn;
        private bool isPaymentInProgress;

        public PaymentTerminal()
        {
            this.Reset();
            this.observers = new List<IObserver>();
        }

        public bool WasAborted { get; private set; }

        public void StartPaymentCycle(ContainableItem item)
        {
            this.Reset();
            this.isPaymentInProgress = true;
            this.currentItem = item;
            this.amountToPay = item.Price;
        }

        public void AddToCurrentAmount(Payment payment)
        {
            this.currentAmount += payment.GetPaymentValue();
            if (this.currentAmount == this.amountToPay)
            {
                this.isPaymentInProgress = false;
            }
            else if (this.currentAmount > this.amountToPay)
            {
                this.isPaymentInProgress = false;
                this.changeToReturn = this.currentAmount - this.amountToPay;
            }
        }

        public void Notify()
        {
            foreach (IObserver observer in this.observers)
            {
                observer.Update(this.currentItem);
            }
        }

        public void AddObserver(IObserver observer)
        {
            this.observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            this.observers.Remove(observer);
        }

        public decimal GetChangeAmount()
        {
            return this.changeToReturn;
        }

        public decimal GetPaidAmount()
        {
            return this.currentAmount;
        }

        public decimal GetLeftAmount()
        {
            return this.amountToPay - this.currentAmount;
        }

        public void AbortPayment()
        {
            this.WasAborted = true;
        }

        public bool IsPaymentInProgress()
        {
            return this.isPaymentInProgress && !this.WasAborted;
        }

        private void Reset()
        {
            this.WasAborted = false;
            this.currentAmount = 0;
            this.currentItem = null;
            this.amountToPay = 0;
            this.changeToReturn = 0;
        }
    }
}
