namespace _04.Team
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var team = new Team("SoftUni");

            for (var i = 0; i < count; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(new []{ ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var firstName = tokens[0];
                var lastName = tokens[1];
                var age = int.Parse(tokens[2]);

                var person = new Person(firstName, lastName, age);
                team.AddPlayer(person);
            }

            Console.WriteLine(team.ToString());
        }
    }
}