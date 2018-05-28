namespace AirConditionerTesterSystem.Models
{
    using System.Text;
    using Contracts;

    public class Report : IReport
    {
        public Report(string manufacturer, string model, int mark)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Mark = mark;
        }

        /// <summary>
        /// Gets and sets a specified manufacturer.
        /// </summary>
        public string Manufacturer { get; }

        /// <summary>
        /// Gets and sets a specified model.
        /// </summary>
        public string Model { get; }

        /// <summary>
        /// Gets and sets the mark result of a test.
        /// </summary>
        public int Mark { get; }

        public override string ToString()
        {
            var result = string.Empty;

            if (this.Mark == 0)
            {
                result = "Failed";
            }
            else if (this.Mark == 1)
            {
                result = "Passed";
            }

            var sb = new StringBuilder();
            sb.AppendLine("Report")
                .AppendLine("====================")
                .AppendLine($"Manufacturer: {this.Manufacturer}")
                .AppendLine($"Model: {this.Model}")
                .AppendLine($"Mark: {result}")
                .AppendLine("====================");

            return sb.ToString().TrimEnd();
        }
    }
}