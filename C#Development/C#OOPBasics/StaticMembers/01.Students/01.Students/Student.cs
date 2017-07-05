namespace _01.Students
{
    public class Student
    {
        public string Name { get; set; }

        public static int countStudent = 0;

        public Student(string name)
        {
            this.Name = name;
            countStudent++;
        }
    }
}
