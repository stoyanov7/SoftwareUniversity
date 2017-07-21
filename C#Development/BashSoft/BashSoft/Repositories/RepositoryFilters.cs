namespace BashSoft.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using IO;
    using StaticData;

    public static class RepositoryFilters
    {
        public static void FilterAndTake(Dictionary<string, List<int>> wantedData, string wantedFilter, int studentToTake)
        {
            switch (wantedFilter)
            {
                case "excellent":
                    FilterAndTake(wantedData, x => x >= 5.0, studentToTake);
                    break;
                case "average":
                    FilterAndTake(wantedData, x => x < 5.0 && x >= 3.5, studentToTake);
                    break;
                case "poor":
                    FilterAndTake(wantedData, x => x < 3.5, studentToTake);
                    break;
                default:
                    OutputWriter.DisplayException(ExceptionMessages.InvalidStudentFilter);
                    break;
            }
        }

        private static void FilterAndTake(Dictionary<string, List<int>> wantedData, Predicate<double> givenFilter, int studentsToTake)
        {
            var counterForPrinted = 0;

            foreach (var userNamePoints in wantedData)
            {
                if (counterForPrinted == studentsToTake)
                {
                    break;
                }

                var averageScore = userNamePoints
                    .Value
                    .Average();

                var percentageOfFullfillments = averageScore / 100;
                var mark = percentageOfFullfillments * (4 + 2);

                if (givenFilter(mark))
                {
                    OutputWriter.PrintStudent(userNamePoints);
                    counterForPrinted++;
                }
            }
        }
    }
}