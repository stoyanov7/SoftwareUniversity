namespace FamilyTree
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var mainPersonInput = Console.ReadLine();
            var familyTreeBuilder = new FamilyTreeBuilder(mainPersonInput);

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                ParseInput(input, familyTreeBuilder);
            }
            
            Console.WriteLine(familyTreeBuilder.Build());
        }

        private static void ParseInput(string input, FamilyTreeBuilder familyTreeBuilder)
        {
            var tokens = input.Split(" - ");

            if (tokens.Length > 1)
            {
                ParentChild(familyTreeBuilder, tokens);
            }
            else
            {
                FullInfo(familyTreeBuilder, tokens);
            }
        }

        private static void FullInfo(FamilyTreeBuilder familyTreeBuilder, string[] tokens)
        {
            tokens = tokens[0].Split();
            var name = $"{tokens[0]} {tokens[1]}";
            var birthday = tokens[2];

            familyTreeBuilder.SetFullInfo(name, birthday);
        }

        private static void ParentChild(FamilyTreeBuilder familyTreeBuilder, IReadOnlyList<string> tokens)
        {
            familyTreeBuilder.SetParentChildRelation(tokens[0], tokens[1]);
        }
    }
}