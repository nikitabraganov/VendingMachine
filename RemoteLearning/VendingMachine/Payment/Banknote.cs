namespace VendingMachine.Payment
{
    using System;

    public sealed class Banknote : Payment
    {
        public Banknote(decimal insertedValue)
        {
            if (!this.IsValidAmount(insertedValue))
            {
                throw new Exception($"The amount entered for a Banknote is not valid! Amount: {insertedValue}");
            }

            this.value = insertedValue;
        }

        protected override bool IsValidAmount(decimal insertedValue)
        {
            switch (insertedValue)
            {
                case 1:
                case 5:
                case 10:
                case 50:
                    return true;
                default:
                    return false;
            }
        }
    }
}
