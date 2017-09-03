namespace _09.TeamworkProjects
{
    using System.Collections.Generic;

    public class Team
    {
        public Team(string name, string creator)
        {
            this.Name = name;
            this.Creator = creator;
            this.Members = new List<string>();
        }

        public string Name { get; set; }

        public string Creator { get; set; }

        public List<string> Members { get; set; }
    }
}