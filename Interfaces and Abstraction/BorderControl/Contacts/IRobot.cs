namespace BorderControl.Contacts
{
    public interface IRobot : ISociety, IIdentifiable
    {
        string Model { get; }
    }
}
