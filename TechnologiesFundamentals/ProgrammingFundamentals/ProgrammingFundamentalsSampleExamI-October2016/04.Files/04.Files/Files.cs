using System;
using System.Collections.Generic;
using System.Linq;

public class Files
{
    public static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var inputData = new Dictionary<string, Dictionary<string, long>>();
        var fileData = new Dictionary<string, long>();

        for (var i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split('\\');
            var fileAndSize = input[input.Length - 1];

            var fileInfo = fileAndSize.Split(';');
            var root = input[0];
            var fileName = fileInfo[0];
            var fileSize = long.Parse(fileInfo[1]);

            if (inputData.ContainsKey(root))
            {
                inputData[root][fileName] = fileSize;
            }
            else
            {
                fileData = new Dictionary<string, long>();
                fileData[fileName] = fileSize;

                inputData[root] = fileData;
            }
        }

        var subject = Console.ReadLine().Split();
        var fileTypeSubject = subject[0];
        var rootSubject = subject[2];

        var areThereResults = false;

        if (inputData.ContainsKey(rootSubject))
        {
            fileData = inputData[rootSubject]
                        .OrderByDescending(id => id.Value)
                        .ThenBy(id => id.Key)
                        .ToDictionary(id => id.Key, id => id.Value);

            foreach (var filePair in fileData)
            {
                var fileNameAndExtension = filePair.Key.Split('.');

                if (fileNameAndExtension[fileNameAndExtension.Length - 1].Equals(fileTypeSubject))
                {
                    areThereResults = true;
                    Console.WriteLine($"{filePair.Key} - {filePair.Value} KB");
                }
            }
        }

        if (!areThereResults)
        {
            Console.WriteLine("No");
        }
    }
}