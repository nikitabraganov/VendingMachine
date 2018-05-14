namespace VendingMachine.Payment
{
    using System;

    public sealed class Coin : Payment
    {
        public Coin(decimal insertedValue)
        {
            if (!this.IsValidAmount(insertedValue))
            {
                throw new Exception($"The amount entered for a Coin is not valid! Amount: {insertedValue}");
            }

            this.value = insertedValue;
        }

        protected override bool IsValidAmount(decimal insertedValue)
        {
            switch (insertedValue)
            {
                case 0.1m:
                case 0.5m:
                    return true;
                default:
                    return false;
            }
        }
    }
}
