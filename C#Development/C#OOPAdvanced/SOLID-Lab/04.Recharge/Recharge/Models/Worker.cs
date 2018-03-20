namespace Recharge.Models
{
    public abstract class Worker
    {
        protected Worker(string id)
        {
            this.Id = id;
        }

        public string Id { get; }

        public int WorkingHours { get; private set; }

        protected void Work(int hours) => this.WorkingHours += hours;
    }
}