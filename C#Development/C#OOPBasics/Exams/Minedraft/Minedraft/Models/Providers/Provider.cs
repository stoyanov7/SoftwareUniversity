namespace Minedraft.Models.Providers
{
    using System;
    using Common;

    public abstract class Provider : Unit
    {
        private const int MinEnergyOutput = 0;
        private const int MaxEnergyOutput = 10000;

        private const string EnergyOutputMessage =
            "Provider is not registered, because of it's EnergyOutput";

        private double energyOutput;

        protected Provider(string id, double energyOutput)
            : base(id)
        {
            this.EnergyOutput = energyOutput;
        }

        public double EnergyOutput
        {
            get => this.energyOutput;

            protected set
            {
                Validator.CheckGivenRange(value, MinEnergyOutput, MaxEnergyOutput, EnergyOutputMessage);
                this.energyOutput = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Type} Provider - {this.Id}{Environment.NewLine}" +
                   $"Energy Output: {this.EnergyOutput}";
        }
    }
}