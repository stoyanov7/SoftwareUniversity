namespace _03.Mankind
{
    using System;
    using System.Text;

    public class Worker : Human
    {
        private const int MinValue = 1;
        private const int MaxValue = 12;

        private decimal weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get => this.weekSalary;

            private set
            {
                if (value < 10)
                {
                    throw new ArgumentException($"Expected value mismatch! Argument: {nameof(weekSalary)}");
                }

                this.weekSalary = value;
            }
        }

        public double WorkHoursPerDay
        {
            get => this.workHoursPerDay;

            private set
            {
                if (value < MinValue || value > MaxValue)
                {
                    throw new ArgumentException($"Expected value mismatch! Argument: {nameof(workHoursPerDay)}");
                }

                this.workHoursPerDay = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"First Name: {this.FirstName}");
            sb.AppendLine($"Last Name: {this.LastName}");
            sb.AppendLine($"Week Salary: {this.WeekSalary:f2}");
            sb.AppendLine($"Hours per day: {this.WorkHoursPerDay:f2}");
            sb.AppendLine($"Salary per hour: {this.GetSalaryPerHour():f2}");

            return sb.ToString();
        }

        private decimal GetSalaryPerHour() => this.WeekSalary / (decimal)(this.WorkHoursPerDay * 5.0);
    }
}