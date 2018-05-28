namespace AirConditionerTesterSystem.Models
{
    using System;
    using System.Text;
    using Contracts;
    using Utilities;
    using Type = Enums.Type;

    public class PlaneAirConditioner : AirConditioner, IPlaneAirConditioner
    {
        private int electricityUsed;
        private int volumeCovered;

        public PlaneAirConditioner(string manufacturer, string model, int volumeCovered, int electricityUsed)
            : base(Type.Plane, manufacturer, model)
        {
            this.VolumeCovered = volumeCovered;
            this.ElectricityUsed = electricityUsed;
        }

        public int VolumeCovered
        {
            get => this.volumeCovered;

            private set
            {
                Validator.CheckNegativeValue(value, string.Format(Constants.NonPositive, "Volume Covered"));
                this.volumeCovered = value;
            }
        }

        public int ElectricityUsed
        {
            get => this.electricityUsed;

            private set
            {
                Validator.CheckNegativeValue(value, string.Format(Constants.NonPositive, "Electricity Used"));
                this.electricityUsed = value;
            }
        }

        public override int Test()
        {
            var sqrtVolume = Math.Sqrt(this.volumeCovered);
            return this.ElectricityUsed / sqrtVolume < Constants.MinPlaneElectricity ? 1 : 0;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(base.ToString())
                .AppendLine($"Volume Covered: {this.VolumeCovered}")
                .AppendLine($"Electricity Used: {this.ElectricityUsed}")
                .AppendLine("====================");

            return sb.ToString().TrimEnd();
        }
    }
}