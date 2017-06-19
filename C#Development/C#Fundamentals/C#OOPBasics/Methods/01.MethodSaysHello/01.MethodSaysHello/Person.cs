namespace _01.MethodSaysHello
{
    public class Person
    {
        public Person(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public string SayHello() => $"{this.Name} says \"Hello\"!";
    }
}
