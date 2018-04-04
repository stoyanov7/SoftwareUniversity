namespace HarvestingFields.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using Model;

    public class Engine
    {
        private bool isRunning;

        public Engine() => this.isRunning = true;

        public void Run()
        {
            var fields = typeof(HarvestingFields)
                .GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            while (this.isRunning)
            {
                var command = Console.ReadLine();

                switch (command)
                {
                    case "public":
                        Console.WriteLine(AppendFields(fields.Where(f => f.IsPublic)));
                        break;
                    case "private":
                        Console.WriteLine(AppendFields(fields.Where(f => f.IsPrivate)));
                        break;
                    case "protected":
                        Console.WriteLine(AppendFields(fields.Where(f => f.IsFamily)));
                        break;
                    case "all":
                        Console.WriteLine(AppendFields(fields));
                        break;
                    case "HARVEST":
                        this.isRunning = false;
                        break;
                }
            }
        }

        private static string AppendFields(IEnumerable<FieldInfo> fieldsCollection)
        {
            var sb = new StringBuilder();

            foreach (var field in fieldsCollection)
            {
                var accessmodifier = field.Attributes.ToString().ToLower();

                if (accessmodifier.Equals("family"))
                {
                    accessmodifier = "protected";
                }

                sb.AppendLine($"{accessmodifier} {field.FieldType.Name} {field.Name}");
            }

            return sb.ToString().Trim();
        }
    }
}