using System;
using System.Linq;

namespace _18.SequenceOfCommands
{
    public class SequenceOfCommands
    {
        private const char ArgumentsDelimiter = ' ';

        public static void Main(string[] args)
        {
            var sizeOfArray = int.Parse(Console.ReadLine());

            var array = Console.ReadLine()
                .Split(ArgumentsDelimiter)
                .Select(long.Parse)
                .ToArray();

            var command = Console.ReadLine()
                .Split(ArgumentsDelimiter)
                .ToArray();

            while (command[0] != "stop")
            {
                var arg = new int[2];

                if (command[0] == "add" ||
                    command[0] == "subtract" ||
                    command[0] == "multiply")
                {

                    arg[0] = int.Parse(command[1]);
                    arg[1] = int.Parse(command[2]);
                    PerformAction(array, command[0], arg);
                }
                else
                {
                    PerformAction(array, command[0], arg);
                }

                PrintArray(array);

                Console.WriteLine();

                command = Console.ReadLine()
                    .Split(ArgumentsDelimiter)
                    .ToArray();
            }
        }

        private static void PerformAction(long[] array, string action, int[] arg)
        {
            var pos = arg[0];
            var value = arg[1];

            switch (action)
            {
                case "multiply":
                    array[pos - 1] *= value;
                    break;
                case "add":
                    array[pos - 1] += value;
                    break;
                case "subtract":
                    array[pos - 1] -= value;
                    break;
                case "lshift":
                    ArrayShiftLeft(array);
                    break;
                case "rshift":
                    ArrayShiftRight(array);
                    break;
            }
        }

        private static void ArrayShiftRight(long[] array)
        {
            var num = array[array.Length - 1];

            for (var i = array.Length - 1; i >= 1; i--)
            {
                array[i] = array[i - 1];
            }

            array[0] = num;
        }

        private static void ArrayShiftLeft(long[] array)
        {
            var num = array[0];

            for (var i = 0; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }

            array[array.Length - 1] = num;
        }

        private static void PrintArray(long[] array)
        {
            foreach (var t in array)
            {
                Console.Write(t + " ");
            }
        }
    }
}
