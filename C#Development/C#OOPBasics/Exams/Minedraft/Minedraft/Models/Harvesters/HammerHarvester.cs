namespace Minedraft.Models.Harvesters
{
    public class HammerHarvester : Harvester
    {
        public HammerHarvester(string id, double oreOutput, double energyRequirement)
            : base(id, oreOutput, energyRequirement)
        {
            this.OreOutput += this.OreOutput * 2;
            this.EnergyRequirement += this.EnergyRequirement * 1;
        }

        public override string Type => "Hammer";
    }
}