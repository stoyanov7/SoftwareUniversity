namespace BashSoft.Repositories
{
    using System;
    using System.Collections.Generic;
    using IO;
    using StaticData;

    public class RepositoryFilters
    {
        public static void FilterAndTake(Dictionary<string, List<int>> wantedData, string wantedFilter, int studentToTake)
        {
            switch (wantedFilter)
            {
                case "excellent":
                    FilterAndTake(wantedData, ExcellentFilter, studentToTake);
                    break;
                case "average":
                    FilterAndTake(wantedData, AverageFilter, studentToTake);
                    break;
                case "poor":
                    FilterAndTake(wantedData, PoorFilter, studentToTake);
                    break;
                default:
                    OutputWriter.DisplayException(ExceptionMessages.InvalidStudentFilter);
                    break;
            }
        }

        private static void FilterAndTake(Dictionary<string, List<int>> wantedData, Predicate<double> givenFilter, int studentToTake)
        {
            var counterForPrintedStudents = 0;

            foreach (var usernamePoints in wantedData)
            {
                if (counterForPrintedStudents == studentToTake)
                {
                    break;
                }

                var averageMark = Average(usernamePoints.Value);

                if (givenFilter(averageMark))
                {
                    OutputWriter.PrintStudent(usernamePoints);
                    counterForPrintedStudents++;
                }
            }
        }

        private static bool ExcellentFilter(double mark) => mark >= 5.0;

        private static bool AverageFilter(double mark) => mark < 5.0 && mark >= 3.5;

        private static bool PoorFilter(double mark) => mark < 3.5;

        private static double Average(List<int> scoreOnTaks)
        {
            var totalScore = 0;

            foreach (var score in scoreOnTaks)
            {
                totalScore += score;
            }

            var percentageOfAll = totalScore / (scoreOnTaks.Count * 100);
            var averageMark = percentageOfAll * (4 + 2);

            return averageMark;
        }
    }
}
