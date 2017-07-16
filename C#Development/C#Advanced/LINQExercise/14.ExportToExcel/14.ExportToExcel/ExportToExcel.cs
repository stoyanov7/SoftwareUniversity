namespace _14.ExportToExcel
{
    using OfficeOpenXml;
    using System;
    using System.IO;

    public class ExportToExcel
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter the full path to your file:");
            var file = Console.ReadLine();

            while (!File.Exists(file))
            {
                OutputWriter.DisplayColorMessage($"This file doesn't exists. Please try again!", ConsoleColor.DarkRed);

                file = Console.ReadLine();
            }

            OutputWriter.DisplayColorMessage("Reading file...", ConsoleColor.DarkGreen);

            try
            {
                using (var reader = new StreamReader(file))
                {
                    using (var excelPackage = new ExcelPackage())
                    {
                        var workSheet = excelPackage
                            .Workbook
                            .Worksheets
                            .Add("Sheet");
                        var row = 1;
                        var line = reader.ReadLine();

                        while (line != null)
                        {
                            var cellData = line.Split('\t');

                            for (var i = 0; i < cellData.Length; i++)
                            {
                                workSheet
                                    .Cells[row, i + 1, row, i + 1]
                                    .Value = cellData[i];
                            }

                            line = reader.ReadLine();
                            row++;
                        }

                        var outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "New Excel.xlsx");
                        excelPackage.SaveAs(new FileInfo(outputFile));
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                OutputWriter.DisplayColorMessage(ex.Message, ConsoleColor.DarkRed);
            }

            OutputWriter.DisplayColorMessage("Ready! Your Excel file is on your Desktop.", ConsoleColor.DarkGreen);
        }
    }
}