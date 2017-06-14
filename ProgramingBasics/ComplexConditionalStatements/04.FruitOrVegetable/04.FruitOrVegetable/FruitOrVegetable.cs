using System;

namespace _04.FruitOrVegetable
{
    public class FruitOrVegetable
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var isFruit = input == "banana" || input == "apple" || input == "kiwi" || input == "cherry" || input == "lemon" || input == "grapes";
            var isVegerable = input == "tomato" || input == "cucumber" || input == "pepper" || input == "carrot";

            if (isFruit)
            {
                Console.WriteLine("fruit");
            }
            else if (isVegerable)
            {
                Console.WriteLine("vegetable");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
