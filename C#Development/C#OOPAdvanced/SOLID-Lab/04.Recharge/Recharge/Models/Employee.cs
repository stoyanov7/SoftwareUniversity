namespace Recharge.Models
{
    using Contracts;

    public class Employee : Worker, ISleeper
    {
        public Employee(string id)
            : base(id)
        {
        }

        public void Sleep()
        {
            // sleep...
        }
    }
}
