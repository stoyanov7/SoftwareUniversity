namespace BashSoft.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using StaticData;
    using IO;

    public static class StudentsRepository
    {
        private static bool isDataInitialized = false;

        private static Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;

        public static void InitializeData(string fileName)
        {
            if (!isDataInitialized)
            {
                OutputWriter.WriteMessageOnNewLine("Reading data...");
                studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
                ReadData(fileName);
            }
            else
            {
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.DataAlreadyInitialisedException);
            }
        }

            {
        {
                OutputWriter.PrintStudent(new KeyValuePair<string, List<int>>(username, studentsByCourse[courseName][username]));
            }

        {
                OutputWriter.WriteMessageOnNewLine($"{courseName}:");
                foreach (var studentMarkEntry in studentsByCourse[courseName])
        }
            }
                RepositorySorters.OrderAndTake(studentsByCourse[courseName], comparison, studentsToTake.Value);

                }
                    studentsToTake = studentsByCourse[courseName].Count;
                {
                if (studentsToTake == null)
            {
            if (IsQueryForCoursePossible(courseName))
        {
        public static void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)

        }
            }

                RepositoryFilters.FilterAndTake(studentsByCourse[courseName], givenFilter, studentsToTake.Value);
                }
                    studentsToTake = studentsByCourse[courseName].Count;
                {
                if (studentsToTake == null)
            {
            if (IsQueryForCoursePossible(courseName))
        {
        public static void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)

        }
            }
                }
                    OutputWriter.PrintStudent(studentMarkEntry);
                {

            {
            if (IsQueryForCoursePossible(courseName))
        public static void GetAllStudentsFromCourse(string courseName)
        }
            if (IsQueryForStudentPossiblе(courseName, username))
        private static void ReadData()
        {
            var input = Console.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {
                // TODO: Split input and initilize variables
                var inputTokens = input
                    .Split(' ')
                    .ToArray();

                var course = inputTokens[0];
                var student = inputTokens[1];
                var mark = int.Parse(inputTokens[2]);

                // TODO: Add the cource and the student if they don't exist
                if (!studentsByCourse.ContainsKey(course))
                {
                    studentsByCourse.Add(course, new Dictionary<string, List<int>>());
                }

                if (!studentsByCourse[course].ContainsKey(student))
                {
                    studentsByCourse[course].Add(student, new List<int>());
                }

                // TODO: Add mark
                studentsByCourse[course][student].Add(mark);

                input = Console.ReadLine(); 
            }

            isDataInitialized = true;
            OutputWriter.WriteMessageOnNewLine("Data read!");
        }

        private static void ReadData(string fileName)
        {
            var path = SessionData.CurrentPath + "\\" + fileName;

            if (File.Exists(path))
            {
                var pattern = @"([A-Z][a-zA-Z#+]*_[A-Z][a-z]{2}_\d{4})\s+([A-Z][a-z]{0,3}\d{2}_\d{2,4})\s+(\d+)";
                var rgx = new Regex(pattern);
                var allInputLines = File.ReadAllLines(path);

                for (int line = 0; line < allInputLines.Length; line++)
                {
                    if (!string.IsNullOrEmpty(allInputLines[line]) && rgx.IsMatch(allInputLines[line]))
                    {
                        var currentMatch = rgx.Match(allInputLines[line]);
                        var courseName = currentMatch.Groups[1].Value;
                        var username = currentMatch.Groups[2].Value;
                        bool hasParsedScore = int.TryParse(currentMatch.Groups[3].Value, out int studentScoreOnTask);

                        if (hasParsedScore && studentScoreOnTask >= 0 && studentScoreOnTask <= 100)
                        {
                            if (!studentsByCourse.ContainsKey(courseName))
                            {
                                studentsByCourse.Add(courseName, new Dictionary<string, List<int>>());
                            }

                            if (!studentsByCourse[courseName].ContainsKey(username))
                            {
                                studentsByCourse[courseName].Add(username, new List<int>());
                            }

                            studentsByCourse[courseName][username].Add(studentScoreOnTask);
                        }
                    }
                }

                isDataInitialized = true;

                OutputWriter.WriteMessageOnNewLine("Data read!");
            }
        }

        private static bool IsQueryForCoursePossible(string courseName)
        {
            if (isDataInitialized)
            {
                if (studentsByCourse.ContainsKey(courseName))
                {
                    return true;
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            return false;
        }

        private static bool IsQueryForStudentPossiblе(string courseName, string studentUserName)
        {
            if (IsQueryForCoursePossible(courseName) && studentsByCourse[courseName].ContainsKey(studentUserName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);
            }

            return false;
        }
    }
}