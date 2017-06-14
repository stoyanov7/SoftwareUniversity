using System;

namespace _10.AnimalType
{
    public class AnimalType
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var result = string.Empty;

            switch (input)
            {
                case "dog":
                    result = "mammal";
                    break;
                case "crocodile":             
                case "tortoise":
                case "snake":
                    result = "reptile";
                    break;
                default:
                    result = "unknown";
                    break;
            }
        }
    }
}
