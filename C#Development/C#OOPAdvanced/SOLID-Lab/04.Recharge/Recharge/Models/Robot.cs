namespace Recharge.Models
{
    using Contracts;

    public class Robot : Worker, IRechargeable
    {
        public Robot(string id, int capacity)
            : base(id)
        {
            this.Capacity = capacity;
        }

        public int Capacity { get; }

        public int CurrentPower { get; set; }

        public void Work(int hours)
        {
            if (hours > this.CurrentPower)
            {
                hours = this.CurrentPower;
            }

            base.Work(hours);
            this.CurrentPower -= hours;
        }

        public void Recharge()
        {
            this.CurrentPower = this.Capacity;
        }
    }
}