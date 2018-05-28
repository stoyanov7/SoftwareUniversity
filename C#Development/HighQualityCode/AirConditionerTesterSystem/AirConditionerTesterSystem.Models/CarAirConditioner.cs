namespace AirConditionerTesterSystem.Models
{
    using System;
    using System.Text;
    using Contracts;
    using Utilities;
    using Type = Enums.Type;

    public class CarAirConditioner : AirConditioner, ICarAirConditioner
    {
        private int volumeCovered;

        public CarAirConditioner(string manufacturer, string model, int volumeCoverage)
            : base(Type.Car, manufacturer, model)
        {
            this.VolumeCovered = volumeCoverage;
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

        public override int Test()
        {
            var sqrtVolume = Math.Sqrt(this.VolumeCovered);

            return sqrtVolume >= Constants.MinCarVolume ? 1 : 0;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .AppendLine($"Volume Covered: {this.VolumeCovered}")
                .AppendLine("====================");

            return sb.ToString().TrimEnd();
        }
    }
}