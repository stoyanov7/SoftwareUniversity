namespace BashSoft.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using IO;
    using StaticData;

    public static class RepositorySorters
    {
        public static void OrderAndTake(Dictionary<string, List<int>> wanterData, string comparison, int studentsToTake)
        {
            comparison = comparison.ToLower();

            switch (comparison)
            {
                case "ascending":
                    PrintStudents(wanterData
                        .OrderBy(x => x.Value.Sum())
                        .Take(studentsToTake)
                        .ToDictionary(x => x.Key, x => x.Value));
                    break;
                case "descending":
                    PrintStudents(wanterData
                        .OrderByDescending(x => x.Value.Sum())
                        .Take(studentsToTake)
                        .ToDictionary(x => x.Key, x => x.Value));
                    break;
                default:
                    OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQuery);
                    break;
            }
        }

        private static void PrintStudents(Dictionary<string, List<int>> studentsSorted)
        {
            foreach (var kvp in studentsSorted)
            {
                OutputWriter.PrintStudent(kvp);
            }
        }
    }
}