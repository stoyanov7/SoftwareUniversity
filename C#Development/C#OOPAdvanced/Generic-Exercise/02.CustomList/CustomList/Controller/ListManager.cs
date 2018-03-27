namespace CustomList.Controller
{
    using System.Collections.Generic;
    using Model;

    public class ListManager
    {
        private readonly CustomList<string> list;

        public ListManager() => this.list = new CustomList<string>();

        public void Add(List<string> cmdArgs) => this.list.Add(cmdArgs[0]);

        public void Remove(List<string> cmdArgs) => this.list.Remove(int.Parse(cmdArgs[0]));

        public bool Contains(List<string> cmdArgs) => this.list.Contains(cmdArgs[0]);

        public void Swap(List<string> cmdArgs) => this.list.Swap(int.Parse(cmdArgs[0]), int.Parse(cmdArgs[1]));

        public int Greater(List<string> cmdArgs) => this.list.GreaterThan(cmdArgs[0]);

        public string Max() => this.list.Max();

        public string Min() => this.list.Min();

        public void Sort() => this.list.Sort();

        public string Print() => this.list.Print();
    }
}