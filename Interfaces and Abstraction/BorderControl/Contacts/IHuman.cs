namespace BorderControl.Contacts
{
    public interface IHuman : ISociety, IIdentifiable, IBirthable
    {
        string Name { get; }

        int Age { get; }
    }
}
