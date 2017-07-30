namespace _03.AnimalFarm
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                var chickenType = typeof(Chicken);
                var fields = chickenType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
                var methods = chickenType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
                Debug.Assert(fields.Count(f => f.IsPrivate) == 2);
                Debug.Assert(methods.Count(m => m.IsPrivate) == 1);

                var name = Console.ReadLine();
                var age = int.Parse(Console.ReadLine());

                var chicken = new Chicken(name, age);
                Console.WriteLine(chicken.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
