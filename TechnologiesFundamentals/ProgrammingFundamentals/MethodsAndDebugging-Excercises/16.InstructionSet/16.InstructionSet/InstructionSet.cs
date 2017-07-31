namespace _16.InstructionSet
{
    using System;
    using System.Linq;

    public class InstructionSet
    {
        public static void Main(string[] args)
        {
            var opCode = Console.ReadLine();
            var result = 0L;

            while (opCode != "END")
            {
                var codeArgs = opCode
                    .Split(' ')
                    .ToArray();

                switch (codeArgs[0])
                {
                    case "INC":
                    {
                        var operandOne = long.Parse(codeArgs[1]);
                        result = operandOne + 1;
                        break;
                    }

                    case "DEC":
                    {
                        var operandOne = long.Parse(codeArgs[1]);
                        result = operandOne - 1;
                        break;
                    }

                    case "ADD":
                    {
                        var operandOne = long.Parse(codeArgs[1]);
                        var operandTwo = long.Parse(codeArgs[2]);
                        result = operandOne + operandTwo;
                        break;
                    }

                    case "MLA":
                    {
                        var operandOne = long.Parse(codeArgs[1]);
                        var operandTwo = long.Parse(codeArgs[2]);
                        result = operandOne * operandTwo;
                        break;
                    }
                }

                Console.WriteLine(result);
                opCode = Console.ReadLine();
            }
        }
    }
}