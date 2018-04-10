namespace _1.EventImplementation.Contracts
{
    public interface INameChangeable : INameable
    {
        void OnNameChange(NameChangeEventArgs args);
    }
}
