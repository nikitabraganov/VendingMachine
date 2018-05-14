namespace VendingMachine.View
{
    public interface IView
    {
        void PrintOneLine(string message);

        void PrintOneLine();

        void Print(string message);
    }
}
