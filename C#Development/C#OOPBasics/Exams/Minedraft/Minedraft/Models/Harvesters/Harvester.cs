using System;

public abstract class Harvester : Unit
{
    private const int MinEnergyRequirement = 0;
    private const int MaxEnergyRequirement = 20000;
    private const string EnergyRequirementMessage = "Harvester is not registered, because of it's EnergyRequirement";

    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement)
        :base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public double OreOutput
    {
        get => this.oreOutput;

        protected set
        {
            Validator.CheckIfNegative(value);
            this.oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get => this.energyRequirement;

        protected set
        {
            Validator.CheckGivenRange(value, MinEnergyRequirement, MaxEnergyRequirement, EnergyRequirementMessage);
            this.energyRequirement = value;
        }
    }

    public override string ToString()
    {
        return $"{this.Type} Harvester - {this.Id}{Environment.NewLine}" +
               $"Ore Output: {this.OreOutput}{Environment.NewLine}" +
               $"Energy Requirement: {this.EnergyRequirement}";
    }
}