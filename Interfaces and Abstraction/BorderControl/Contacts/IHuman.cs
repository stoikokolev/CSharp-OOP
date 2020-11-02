namespace BorderControl.Contacts
{
    public interface IHuman : IIdentifiable
    {
        string Name { get; }

        int Age { get; }
    }
}
