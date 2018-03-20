namespace DetailPrinter
{
    using System;
    using System.Collections.Generic;

    public class Manager : Employee
    {
        public Manager(string name, IEnumerable<string> documents)
            : base(name)
        {
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + string.Join(Environment.NewLine, this.Documents);
        }
    }
}
