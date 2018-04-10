namespace _1.EventImplementation
{
    using Contracts;

    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);

    public class Dispatcher : INameChangeable
    {
        public event NameChangeEventHandler NameChange;
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                var args = new NameChangeEventArgs(value);
                OnNameChange(args);
            }
        }

        //public Dispatcher(string name)
        //{
        //    Name = name;
        //}
        
        public void OnNameChange(NameChangeEventArgs args)
        {
            if (this.NameChange != null)
            {
                this.NameChange.Invoke(this, args);
            }
        }
    }
}
