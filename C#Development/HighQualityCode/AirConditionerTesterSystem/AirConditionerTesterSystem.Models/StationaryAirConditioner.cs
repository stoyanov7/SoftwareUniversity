namespace AirConditionerTesterSystem.Models
{
    using System;
    using System.Text;
    using Contracts;
    using Utilities;
    using Type = Enums.Type;

    public class StationaryAirConditioner : AirConditioner, IStationaryAirConditioner
    {
        private int powerUsage;
        private char requiredEnergyEfficiencyRating;

        public StationaryAirConditioner(string manufacturer, string model, char requiredEnergyEfficiencyRating, int powerUsage) 
            : base(Type.Stationary, manufacturer, model)
        {
            this.PowerUsage = powerUsage;
            this.RequiredEnergyEfficiencyRating = requiredEnergyEfficiencyRating;
            this.SetEfficiencyRating();
        }

        public char RequiredEnergyEfficiencyRating
        {
            get => this.requiredEnergyEfficiencyRating;

            private set
            {
                if (value != 'A' && value != 'B' && value != 'C' && value != 'D' && value != 'E')
                {
                    throw new ArgumentException(Constants.IncorrectRating);
                }

                this.requiredEnergyEfficiencyRating = value;
            }
        }

        public int PowerUsage
        {
            get => this.powerUsage;

            private set
            {
                Validator.CheckNegativeValue(value, string.Format(Constants.NonPositive, "Power Usage"));
                this.powerUsage = value;
            }
        }

        public char ActualEnergyEfficiencyRating { get; set; }

        public override int Test()
        {
            return this.ActualEnergyEfficiencyRating 
                   <= this.RequiredEnergyEfficiencyRating ? 1 : 0;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToString())
                .AppendLine($"Required energy efficiency rating: {this.RequiredEnergyEfficiencyRating}")
                .AppendLine($"Power Usage(KW / h): {this.PowerUsage}")
                .AppendLine("====================");

            return sb.ToString().TrimEnd();
        }

        private void SetEfficiencyRating()
        {
            if (this.PowerUsage > 2000)
            {
                this.ActualEnergyEfficiencyRating = 'E';
            }
            else if (this.PowerUsage <= 2000 && this.PowerUsage >= 1501)
            {
                this.ActualEnergyEfficiencyRating = 'D';
            }
            else if (this.PowerUsage <= 1500 && this.PowerUsage >= 1251)
            {
                this.ActualEnergyEfficiencyRating = 'C';
            }
            else if (this.PowerUsage <= 1250 && this.PowerUsage >= 1000)
            {
                this.ActualEnergyEfficiencyRating = 'B';
            }
            else if (this.PowerUsage < 1000)
            {
                this.ActualEnergyEfficiencyRating = 'A';
            }
        }
    }
}