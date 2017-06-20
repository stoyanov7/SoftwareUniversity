using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Exercises
{
    public class Exercises
    {
        public static void Main(string[] args)
        {
            var exercises = new List<Exercise>();
            var line = Console.ReadLine();

            while (!line.Equals("go go go"))
            {
                ReadExcercise(exercises, line);

                line = Console.ReadLine();
            }

            PrintExcercise(exercises);
        }

        private static void ReadExcercise(List<Exercise> exercises, string line)
        {
            var lineTokens = line
                                .Split("-> ,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                                .Select(e => e.Trim())
                                .ToArray();

            var topic = lineTokens[0];
            var courseName = lineTokens[1];
            var judgeContestLink = lineTokens[2];
            var problems = lineTokens.Skip(3).ToList();

            var exercise = new Exercise(topic, courseName, judgeContestLink, problems);
            exercises.Add(exercise);
        }

        private static void PrintExcercise(List<Exercise> exercises)
        {
            foreach (var exercise in exercises)
            {
                Console.WriteLine($"Exercises: {exercise.Topic}");
                Console.WriteLine($"Problems for exercises and homework for the \"{exercise.CourseName}\" course @ SoftUni.");
                Console.WriteLine($"Check your solutions here: {exercise.JudgeContestLink}");

                var count = 1;

                foreach (var problem in exercise.Problems)
                {
                    Console.WriteLine($"{count}. {problem}");
                    count++;
                }
            }
        }
    }
}
