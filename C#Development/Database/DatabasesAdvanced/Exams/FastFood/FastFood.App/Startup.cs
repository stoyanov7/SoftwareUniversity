namespace FastFood.App
{
    using System;
    using System.IO;
    using AutoMapper;
    using Data;
    using DataProcessor;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var context = new FastFoodDbContext();

            ResetDatabase(context);

            Console.WriteLine("Database Reset.");

            Mapper.Initialize(cfg => cfg.AddProfile<FastFoodProfile>());

            ImportEntities(context);
            ExportEntities(context);
        }

        private static void ResetDatabase(FastFoodDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

        }

        private static void ImportEntities(FastFoodDbContext context, string baseDir = @"..\Datasets\")
        {
            const string exportDir = "./ImportResults/";

            var employees = Deserializer.ImportEmployees(context, File.ReadAllText(baseDir + "employees.json"));
            PrintAndExportEntityToFile(employees, exportDir + "Employees.txt");

            var items = Deserializer.ImportItems(context, File.ReadAllText(baseDir + "items.json"));
            PrintAndExportEntityToFile(items, exportDir + "Items.txt");

            var orders = Deserializer.ImportOrders(context, File.ReadAllText(baseDir + "orders.xml"));
            PrintAndExportEntityToFile(orders, exportDir + "Orders.txt");
        }

        private static void ExportEntities(FastFoodDbContext context)
        {
            const string exportDir = "./ImportResults/";

            var jsonOutput = Serializer.ExportOrdersByEmployee(context, "Avery Rush", "ToGo");
            Console.WriteLine(jsonOutput);
            File.WriteAllText(exportDir + "OrdersByEmployee.json", jsonOutput);


            var xmlOutput = Serializer.ExportCategoryStatistics(context, "Chicken,Drinks,Toys");
            Console.WriteLine(xmlOutput);
            File.WriteAllText(exportDir + "CategoryStatistics.xml", xmlOutput);
        }

        private static void PrintAndExportEntityToFile(string entityOutput, string outputPath)
        {
            Console.WriteLine(entityOutput);
            File.WriteAllText(outputPath, entityOutput.TrimEnd());
        }
    }
}
