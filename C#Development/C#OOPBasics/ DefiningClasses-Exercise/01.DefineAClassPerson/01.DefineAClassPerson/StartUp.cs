using System;
using System.Reflection;

namespace _01.DefineAClassPerson
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var personType = typeof(Person);
            var fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine(fields.Length);
        }
    }
}
