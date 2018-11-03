namespace Torshia.Models
{
    using System;

    using Torshia.Models.Enums;

    public class Report : BaseModel<int>
    {
        public Status Status { get; set; }

        public DateTime ReportedOn { get; set; }

        public int TaskId { get; set; }

        public Task Task { get; set; }

        public int ReporterId { get; set; }

        public User Reporter { get; set; }
    }
}