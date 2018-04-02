namespace EqualityLogic
{
    using System.Collections.Generic;

    public class PersonEqualityComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person firstPerson, Person secondPerson) => firstPerson.CompareTo(secondPerson) == 0;

        public int GetHashCode(Person person) => $"{person.Name} {person.Age}".GetHashCode();
    }
}