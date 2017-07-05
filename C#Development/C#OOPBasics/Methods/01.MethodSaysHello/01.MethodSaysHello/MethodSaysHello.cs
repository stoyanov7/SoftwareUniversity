using System;
using System.Reflection;

namespace _01.MethodSaysHello
{
    public class MethodSaysHello
    {
        public static void Main(string[] args)
        {
            var personName = Console.ReadLine();
            var person = new Person(personName);

            Console.WriteLine(person.SayHello());

            var personType = typeof(Person);
            var fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            var methods = personType.GetMethods(BindingFlags.Public | BindingFlags.Instance);

            if (fields.Length != 1 || methods.Length != 5)
            {
                throw new Exception();
            }
        }
    }
}
