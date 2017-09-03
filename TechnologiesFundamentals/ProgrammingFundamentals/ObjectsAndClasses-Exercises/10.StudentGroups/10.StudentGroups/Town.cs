namespace _10.StudentGroups
{
    using System.Collections.Generic;

    public class Town
    {
        public Town(string name, int seatsCount)
        {
            this.Name = name;
            this.SeatsCount = seatsCount;
            this.Students = new List<Student>();
        }

        public string Name { get; set; }

        public int SeatsCount { get; set; }

        public List<Student> Students { get; set; }
    }
}