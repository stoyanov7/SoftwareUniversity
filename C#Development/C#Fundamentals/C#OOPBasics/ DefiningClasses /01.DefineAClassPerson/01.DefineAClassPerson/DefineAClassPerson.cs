using System;
using System.Reflection;

namespace _01.DefineAClassPerson
{
    public class DefineAClassPerson
    {
        public static void Main(string[] args)
        {
            Type personType = typeof(Person);
            FieldInfo[] fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine(fields.Length);
        }
    }
}
