namespace StudentSystem
{
    using System;
    using System.Collections.Generic;

    public class StudentSystem
    {
        private readonly Dictionary<string, Student> repo;

        public StudentSystem()
        {
            this.repo = new Dictionary<string, Student>();
        }

        public void ParseCommand(string command, Action<string> printFunction)
        {
            var args = command.Split();

            if (args[0] == "Create")
            {
                this.Create(args[1], args[2], args[3]);
            }
            else if (args[0] == "Show")
            {
                var studentName = args[1];

                if (this.repo.ContainsKey(studentName))
                {
                    printFunction(this.repo[studentName].ToString());
                }
            }
        }

        private void Create(string name, string ageStr, string gradeStr)
        {
            var age = int.Parse(ageStr);
            var grade = double.Parse(gradeStr);

            if (!this.repo.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                this.repo[name] = student;
            }
        }
    }
}