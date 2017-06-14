namespace _03.OpinionPoll
{
    public class Person
    {
        private static string DEFAULT_NAME = "No name";
        private static int DEFAULT_AGE = 1;

        public string Name { get; set; }

        public int Age { get; set; }

        public Person()
        {
            this.Name = DEFAULT_NAME;
            this.Age = DEFAULT_AGE;
        }

        public Person(int age) : this()
        {
            this.Age = age;
        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}
