namespace VendingMachine.Payment
{
    public abstract class Payment
    {
        protected decimal value;

        public decimal GetPaymentValue()
        {
            return this.value;
        }

        protected abstract bool IsValidAmount(decimal insertedValue);
    }
}
