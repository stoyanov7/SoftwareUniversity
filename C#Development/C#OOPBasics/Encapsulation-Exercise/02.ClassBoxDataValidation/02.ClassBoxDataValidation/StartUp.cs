namespace _02.ClassBoxDataValidation
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                var boxType = typeof(Box);
                var fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
                Console.WriteLine(fields.Count());

                var length = double.Parse(Console.ReadLine());
                var width = double.Parse(Console.ReadLine());
                var height = double.Parse(Console.ReadLine());

                var box = new Box(length, width, height);
                Console.WriteLine(box.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
