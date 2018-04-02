namespace StrategyPattern.Comparers
{
    using System.Collections.Generic;
    using Models;

    public class PersonAgeComparer : IComparer<Person>
    {
        public int Compare(Person firstPerson, Person secondPerson)
        {
            return firstPerson.Age.CompareTo(secondPerson.Age);
        }
    }
}