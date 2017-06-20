using System.Collections.Generic;

namespace _01.Exercises
{
    public class Exercise
    {
        public string Topic { get; set; }

        public string CourseName { get; set; }

        public string JudgeContestLink { get; set; }

        public List<string> Problems { get; set; }

        public Exercise(string topic, string couseName, string judgeContestLink, List<string> problems)
        {
            this.Topic = topic;
            this.CourseName = couseName;
            this.JudgeContestLink = judgeContestLink;
            this.Problems = problems;
        }
    }
}
