namespace CreateCustomClassAttribute.Controller
{
    using System;
    using Attribute;
    using Model;

    public class Engine
    {
        public void Run()
        {
            var typeWeapon = typeof(Weapon);
            var input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                var attribute = (CustomAttribute)Attribute.GetCustomAttribute(typeWeapon, typeof(CustomAttribute));
                var result = Print(input, attribute);
                Console.WriteLine(result);
            }
        }

        private static string Print(string input, CustomAttribute attribute)
        {
            switch (input)
            {
                case "Author":
                    return $"Author: {attribute.Author}";
                case "Revision":
                    return $"Revision: {attribute.Revision}";
                case "Description":
                    return $"Class description: {attribute.Description}";
                case "Reviewers":
                    return "Reviewers: " + string.Join(", ", attribute.Reviewers);
            }

            return null;
        }
    }
}