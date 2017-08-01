namespace _04.TrippleSum
{
    using System;
    using System.Linq;

    public class TrippleSum
    {
        public static void Main(string[] args)
        {
            var array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse).
                ToArray();

            var hasFoundSum = false;

            for (var i = 0; i < array.Length; i++)
            {
                for (var j = i + 1; j < array.Length; j++)
                {
                    var sum = array[i] + array[j];

                    if (array.Contains(sum))
                    {
                        Console.WriteLine($"{array[i]} + {array[j]} == {sum}");
                        hasFoundSum = true;
                        break;
                    }
                }
            }

            if (!hasFoundSum)
            {
                Console.WriteLine("No");
            }
        }
    }
}