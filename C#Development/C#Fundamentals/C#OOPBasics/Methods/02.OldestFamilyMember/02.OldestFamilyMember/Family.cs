using System.Collections.Generic;
using System.Linq;

namespace _02.OldestFamilyMember
{
    public class Family
    {
        public List<Person> Persons { get; set; }

        public Family() => this.Persons = new List<Person>();

        public void AddMember(Person member) => this.Persons.Add(member);

        public Person GetOldestMember() =>
            this.Persons
            .OrderByDescending(p => p.Age)
            .First();
    }
}