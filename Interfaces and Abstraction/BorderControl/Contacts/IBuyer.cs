namespace BorderControl.Contacts
{
    public interface IBuyer : IPerson
    {
        int Food { get; }

        void BuyFood();
    }
}
