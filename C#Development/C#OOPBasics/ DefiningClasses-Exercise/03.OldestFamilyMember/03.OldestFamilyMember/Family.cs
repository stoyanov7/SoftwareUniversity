namespace _03.OldestFamilyMember
{
    using System.Collections.Generic;
    using System.Linq;

    public class Family
    {
        public Family() => this.Persons = new List<Person>();

        public List<Person> Persons { get; }

        public void AddMember(Person p) => this.Persons.Add(p);

        public Person GetOldestMember(List<Person> people)
        {
            return people
                .FirstOrDefault(x => x.Age == people.Max(y => y.Age));
        }
    }
}