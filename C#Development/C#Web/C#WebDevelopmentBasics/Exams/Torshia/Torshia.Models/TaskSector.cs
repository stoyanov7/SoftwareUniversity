namespace Torshia.Models
{
    using Torshia.Models.Enums;

    public class TaskSector : BaseModel<int>
    {
        public Sector Sector { get; set; }

        public int TaskId { get; set; }

        public Task Task { get; set; }
    }
}