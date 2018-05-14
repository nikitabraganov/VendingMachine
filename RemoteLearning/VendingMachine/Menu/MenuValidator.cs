namespace VendingMachine.Menu
{
    using System.Linq;

    public class MenuValidator
    {
        public static bool ValidateInput(string input, int[] validChoices, out int validatedInput)
        {
            validatedInput = 0;

            bool isValid = int.TryParse(input, out int numericInput);
            if (!isValid)
            {
                return false;
            }

            if (!validChoices.Contains(numericInput))
            {
                return false;
            }

            validatedInput = numericInput;

            return true;
        }

        public static bool ValidateSelectedCell(string input)
        {
            return PositionValidator.ValidatePosition(input);
        }
    }
}
