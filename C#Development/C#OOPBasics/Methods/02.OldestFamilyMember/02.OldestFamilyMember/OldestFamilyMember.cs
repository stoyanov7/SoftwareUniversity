using System;

namespace _02.OldestFamilyMember
{
    public class OldestFamilyMember
    {
        public static void Main(string[] args)
        {
            var family = new Family();
            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(' ');
                var name = tokens[0];
                var age = int.Parse(tokens[1]);
                var person = new Person(name, age);
                family.AddMember(person);
            }

            var oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
            var addMemberMethod = typeof(Family).GetMethod("AddMember");

            if (oldestMemberMethod == null || addMemberMethod == null)
            {
                throw new Exception();
            }

            Console.WriteLine(family.GetOldestMember().ToString());
        }
    }
}