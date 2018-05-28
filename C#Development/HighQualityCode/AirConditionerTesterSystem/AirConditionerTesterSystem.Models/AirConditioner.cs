namespace AirConditionerTesterSystem.Models
{
    using System.Text;
    using Contracts;
    using Type = Enums.Type;
    using Utilities;

    public abstract class AirConditioner : IAirConditioner
    {
        private string manufacturer;
        private string model;

        protected AirConditioner(Type type, string manufacturer, string model)
        {
            this.Type = type;
            this.Manufacturer = manufacturer;
            this.Model = model;
        }

        public Type Type { get; }

        public string Manufacturer
        {
            get => this.manufacturer;

            private set
            {
                Validator.CheckProperty(value,
                    Constants.ManufacturerMinLength,
                    string.Format(Constants.IncorrectPropertyNameLength, "Manufacturer", Constants.ManufacturerMinLength));

                this.manufacturer = value;
            }
        }

        public string Model
        {
            get => this.model;

            private set
            {
                Validator.CheckProperty(
                    value,
                    Constants.ModelMinLength,
                    string.Format(Constants.IncorrectPropertyNameLength, "Model", Constants.ModelMinLength));

                this.model = value;
            }
        }

        public abstract int Test();

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Air Conditioner")
                .AppendLine("====================")
                .AppendLine($"Manufacturer: {this.Manufacturer}")
                .AppendLine($"Model: {this.Model}");

            return sb.ToString().TrimEnd();
        }
    }
}
