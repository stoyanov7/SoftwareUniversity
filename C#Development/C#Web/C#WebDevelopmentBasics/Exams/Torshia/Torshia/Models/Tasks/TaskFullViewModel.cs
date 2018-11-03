namespace Torshia.Models.Tasks
{
    using System.Collections.Generic;
    using System.Linq;

    public class TaskFullViewModel
    {
        public string Title { get; set; }

        public string DueDate { get; set; }

        public string Description { get; set; }

        public string Participants { get; set; }

        public string Customers { get; set; }

        public string Marketing { get; set; }

        public string Finances { get; set; }

        public string Internal { get; set; }

        public string Management { get; set; }

        public ICollection<string> AffectedSectors
        {
            get =>
                new string[] { this.Customers, this.Marketing, this.Finances, this.Internal, this.Management }
                    .Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
            set
            { }
        }
    }
}