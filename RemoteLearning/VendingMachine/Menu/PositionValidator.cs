namespace VendingMachine.Menu
{
    using System.Text.RegularExpressions;

    using VendingMachine.ContainableItem;

    public class PositionValidator
    {
        public static bool ValidatePosition(string input)
        {
            bool isMatch = Regex.IsMatch(input.ToUpper(), "([1-5][1-5])");
            return isMatch;
        }
    }
}
