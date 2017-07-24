namespace _12.Google
{
    public class Child
    {
        private string name;
        private string birthday;

        public Child(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public string Name { get; set; }

        public string Birthday { get; set; }

        public override string ToString() => $"{this.Name} {this.Birthday}";
    }
}