namespace _03.OldestFamilyMember
{
    using System.Collections.Generic;
    using System.Linq;

    public class Family
    {
        private List<Person> persons;

        public Family() => this.Persons = new List<Person>();

        public List<Person> Persons
        {
            get => this.persons;
            set => this.persons = value;
        }

        public void AddMember(Person p) => this.Persons.Add(p);

        public Person GetOldestMember(List<Person> people)
        {
            return people
                .FirstOrDefault(x => x.Age == people.Max(y => y.Age));
        }
    }
}