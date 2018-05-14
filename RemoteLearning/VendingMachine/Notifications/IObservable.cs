namespace VendingMachine.Notifications
{
    public interface IObservable
    {
        void AddObserver(IObserver observer);

        void RemoveObserver(IObserver observer);

        void Notify();
    }
}
