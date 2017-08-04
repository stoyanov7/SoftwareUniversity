namespace BashSoft.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using IO;
    using StaticData;

    /// <summary>
    /// Student data stucture.
    /// </summary>
    public static class StudentsRepository
    {
        private static bool isDataInitialized = false;
        //// Dictionary<courseName, Dictionary<student, scoresOnTask
        private static Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;

        /// <summary>
        /// Initialize data stucture and fill it.
        /// </summary>
        /// <param name="fileName"></param>
        /// <seealso cref="ReadData()">If it is not initialized yet,
        /// reads the data</seealso>
        /// <seealso cref="ExceptionMessages.DataAlreadyInitialisedException">
        /// If data is initialized print message.</seealso>
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

        /// <summary>
        /// Get given student from a given couse if the query for student is possible.
        /// </summary>
        /// <param name="courseName">Given course name.</param>
        /// <param name="username">Given student user name.</param>
        public static void GetStudentScoreFromCourese(string courseName, string username)
        {
            if (IsQueryForStudentPossiblе(courseName, username))
            {
                OutputWriter.PrintStudent(new KeyValuePair<string, List<int>>(username, studentsByCourse[courseName][username]));
            }
        }

        /// <summary>
        /// Gets all students and marks from a given course if the query for course is possible.
        /// </summary>
        /// <param name="courseName">Given course name.</param>
        /// <seealso cref="OutputWriter.PrintStudent"/>
        public static void GetAllStudentsFromCourse(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"Course {courseName}:");

                // TODO: Print students and marks
                foreach (var studentMarkEntry in studentsByCourse[courseName])
                {
                    OutputWriter.PrintStudent(studentMarkEntry);
                }
            }
        }

        /// <summary>
        /// Read data from the console until an empty line is read.
        /// </summary>
        /// <remarks>
        /// Format of reading data:
        /// [course name] [student user name] [mark]
        /// </remarks>
        private static void ReadData()
        {
            var line = Console.ReadLine();

            while (!string.IsNullOrEmpty(line))
            {
                // TODO: Read the data
                var lineTokens = line
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var course = lineTokens[0];
                var student = lineTokens[1];
                var mark = int.Parse(lineTokens[2]);

                // TODO: Add the course if they don't exist
                if (!studentsByCourse.ContainsKey(course))
                {
                    studentsByCourse.Add(course, new Dictionary<string, List<int>>());
                }

                // TODO: Add the student if the don't exist
                if (!studentsByCourse[course].ContainsKey(student))
                {
                    studentsByCourse[course].Add(student, new List<int>());
                }

                // TODO: Add the mark
                studentsByCourse[course][student].Add(mark);

                line = Console.ReadLine();
                isDataInitialized = true;
            }

            OutputWriter.WriteMessageOnNewLine("Data read!");
        }

        private static void ReadData(string fileName)
        {
            var path = SessionData.CurrentPath + "\\" + fileName;

            if (File.Exists(path))
            {
                var allInputLines = File.ReadAllLines(path);

                for (var line = 0; line < allInputLines.Length; line++)
                {
                    if (!string.IsNullOrEmpty(allInputLines[line]))
                    {
                        var data = allInputLines[line]
                            .Split(' ')
                            .ToArray();

                        var fileNames = data[1];
                        StudentsRepository.InitializeData(fileNames);
                    }
                }

                isDataInitialized = true;
                OutputWriter.WriteMessageOnNewLine("Data read!");
            }
        }

        /// <summary>
        /// Check for given course name is wheather in data stucture
        /// is actually initialized.
        /// </summary>
        /// <param name="courseName"></param>
        /// <returns>Return true if data structure has been initialized and
        /// database contains course name (bool).</returns>
        /// <seealso cref="ExceptionMessages.DataNotInitializedExceptionMessage"> 
        /// In other case display an exception.</seealso>
        private static bool IsQueryForCoursePossible(string courseName)
        {
            if (isDataInitialized)
            {
                if (studentsByCourse.ContainsKey(courseName))
                {
                    return true;
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            return false;
        }

        /// <summary>
        /// Checks for whether the given student username exists in
        /// the data structure.
        /// </summary>
        /// <param name="courseName"></param>
        /// <param name="studentUserName"></param>
        /// <returns>If it present return true (bool).</returns>
        /// <seealso cref="ExceptionMessages.InexistingStudentInDataBase"> 
        /// If it is not present.</seealso>
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