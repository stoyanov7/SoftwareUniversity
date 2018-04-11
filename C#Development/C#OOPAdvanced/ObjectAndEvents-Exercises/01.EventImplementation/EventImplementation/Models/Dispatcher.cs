namespace EventImplementation.Models
{
    using Contracts;

    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs e);

    public class Dispatcher : IDispatcher
    {
        private string name;

        public event NameChangeEventHandler NameChange;

        public string Name
        {
            get => this.name;

            set
            {
                this.name = value;
                this.OnNameChange(new NameChangeEventArgs(value));
            }
        }

        private void OnNameChange(NameChangeEventArgs e)
        {
            this.NameChange?.Invoke(this, e);
        }
    }
}