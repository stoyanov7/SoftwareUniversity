namespace CarSalesman.Models
{
    using System.Text;

    public class Engine
    {
        private const string Offset = "  ";
        
        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = -1;
            this.Efficiency = "n/a";
        }

        public Engine(string model, int power, int displacement)
            :this(model, power)
        {
            this.Displacement = displacement;
            this.Efficiency = "n/a";
        }

        public Engine(string model, int power, string efficiency)
            :this(model, power)
        {
            this.Displacement = -1;
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency)
            :this(model, power, displacement)
        {
            this.Efficiency = efficiency;
        }

        public string Model { get; private set; }

        public int Power { get; private set; }

        public int Displacement { get; private set; }

        public string Efficiency { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Offset}{this.Model}:");
            sb.AppendFormat("{0}{0}Power: {1}\n", Offset, this.Power);
            sb.AppendFormat("{0}{0}Displacement: {1}\n", Offset, this.Displacement == -1 ? "n/a" : this.Displacement.ToString());
            sb.AppendFormat("{0}{0}Efficiency: {1}\n", Offset, this.Efficiency);

            return sb.ToString();
        }
    }
}