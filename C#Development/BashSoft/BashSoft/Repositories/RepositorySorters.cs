namespace BashSoft.Repositories
{
    using System;
    using System.Collections.Generic;
    using IO;
    using StaticData;

    public class RepositorySorters
    {
        public static void OrderAndTake(Dictionary<string, List<int>> wanterData, string comparison, int studentsToTake)
        {
            comparison = comparison.ToLower();

            switch (comparison)
            {
                case "ascending":
                    OrderAndTake(wanterData, studentsToTake, CompareInOrder);
                    break;
                case "descending":
                    OrderAndTake(wanterData, studentsToTake, CompareInDesendingOrder);
                    break;
                default:
                    OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQuery);
                    break;
            }
        }

        private static void OrderAndTake(Dictionary<string, List<int>> wantedData, int studentsToTake, Func<KeyValuePair<string, List<int>>, KeyValuePair<string, List<int>>, int> comparisonFunc)
        {
            // TODO: ???
        }

        private static int CompareInOrder(KeyValuePair<string, List<int>> firstValue, KeyValuePair<string, List<int>> secondValue)
        {
            var totalOfFirstMark = 0;

            foreach (var i in firstValue.Value)
            {
                totalOfFirstMark += i;
            }

            var totalOfSecondMark = 0;

            foreach (var i in secondValue.Value)
            {
                totalOfSecondMark += i;
            }

            return totalOfSecondMark.CompareTo(totalOfFirstMark);
        }

        private static int CompareInDesendingOrder(KeyValuePair<string, List<int>> firstValue, KeyValuePair<string, List<int>> secondValue)
        {
            var totalOfFirstMark = 0;

            foreach (var i in firstValue.Value)
            {
                totalOfFirstMark += i;
            }

            var totalOfSecondMark = 0;

            foreach (var i in secondValue.Value)
            {
                totalOfSecondMark += i;
            }

            return totalOfFirstMark.CompareTo(totalOfSecondMark);
        }

        private static Dictionary<string, List<int>> GetSortedStudents(Dictionary<string, List<int>> studentsWanted, int takeCount, Func<KeyValuePair<string, List<int>>, KeyValuePair<string, List<int>>, int> comaprison)
        {
            var valuesTaken = 0;
            var studentsSorted = new Dictionary<string, List<int>>();
            var nextInOrder = new KeyValuePair<string, List<int>>();
            var isSorted = false;

            while (valuesTaken < takeCount)
            {
                isSorted = true;

                foreach (var studentsWithScore in studentsWanted)
                {
                    if (!string.IsNullOrEmpty(nextInOrder.Key))
                    {
                        var comparisonResult = comaprison(studentsWithScore, nextInOrder);

                        if (comparisonResult >= 0 && !studentsSorted.ContainsKey(studentsWithScore.Key))
                        {
                            nextInOrder = studentsWithScore;
                            isSorted = false;
                        }
                    }
                    else
                    {
                        if (!studentsSorted.ContainsKey(studentsWithScore.Key))
                        {
                            nextInOrder = studentsWithScore;
                            isSorted = true;
                        }
                    }
                }

                if (!isSorted)
                {
                    studentsSorted.Add(nextInOrder.Key, nextInOrder.Value);
                    valuesTaken++;
                    nextInOrder = new KeyValuePair<string, List<int>>();
                }
            }

            return studentsSorted;
        }
    }
}