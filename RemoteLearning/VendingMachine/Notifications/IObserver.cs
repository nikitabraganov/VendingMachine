namespace VendingMachine.Notifications
{
    using VendingMachine.ContainableItem;

    public interface IObserver
    {
        void Update(ContainableItem obj);
    }
}
