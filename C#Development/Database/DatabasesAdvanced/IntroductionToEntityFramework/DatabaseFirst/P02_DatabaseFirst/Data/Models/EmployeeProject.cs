namespace P02_DatabaseFirst.Data.Models
{

    public class EmployeeProject 
    {
        public int EmployeeId { get; private set; }
        public Employee Employee { get; private set; }

        public int ProjectId { get; private set; }
        public Project Project { get; private set; }
    }
}
