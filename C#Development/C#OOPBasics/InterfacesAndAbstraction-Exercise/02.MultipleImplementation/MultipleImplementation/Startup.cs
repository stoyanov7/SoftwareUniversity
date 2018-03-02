namespace MultipleImplementation
{
    using System;
    using Contracts;
    using Models;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var name = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var id = Console.ReadLine();
            var birthdate = Console.ReadLine();

            IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
            IBirthable birthable = new Citizen(name, age, id, birthdate);

            Console.WriteLine(identifiable.Id);
            Console.WriteLine(birthable.Birthdate);
        }
    }
}