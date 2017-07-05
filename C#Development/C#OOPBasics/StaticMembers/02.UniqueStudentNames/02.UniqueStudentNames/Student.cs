namespace _02.UniqueStudentNames
{
    public class Student
    {
        public string Name { get; set; }

        public Student(string name)
        {
            this.Name = name;
            StrudentGroup.UniqueStudents.Add(this.Name);
        }
    }
}
