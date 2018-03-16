namespace Minedraft.Models.Providers
{
    public class SolarProvider : Provider
    {
        public SolarProvider(string id, double energyOutput)
            : base(id, energyOutput)
        {
        }

        public override string Type => "Solar";
    }
}