namespace _10.GroupbyGroup
{
    public class Person
    {
        public Person(string name, int group)
        {
            this.Name = name;
            Group = group;
        }

        public string Name { get; set; }

        public int Group { get; set; }
    }
}