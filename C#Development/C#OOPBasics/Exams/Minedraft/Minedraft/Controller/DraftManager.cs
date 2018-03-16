namespace Minedraft.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Factory;
    using Models;
    using Models.Harvesters;
    using Models.Providers;

    public class DraftManager
    {
        private readonly List<Harvester> harvesters;
        private readonly List<Provider> providers;
        private readonly HarvesterFactory harvesterFactory;
        private readonly ProviderFactory providerFactory;
        private double totalEnergyStored;
        private double totalMinedOre;
        private string mode;

        public DraftManager()
        {
            this.harvesters = new List<Harvester>();
            this.providers = new List<Provider>();
            this.harvesterFactory = new HarvesterFactory();
            this.providerFactory = new ProviderFactory();
            this.mode = "Full";
            this.totalEnergyStored = 0.0;
            this.totalMinedOre = 0.0;
        }

        public string RegisterHarvester(List<string> arguments)
        {
            try
            {
                var harvester = this.harvesterFactory.CreateHarvester(arguments);
                this.harvesters.Add(harvester);

                return $"Successfully registered {harvester.Type} Harvester - {harvester.Id}";
            }
            catch (ArgumentException ae)
            {
                return ae.Message;
            }
        }

        public string RegisterProvider(List<string> arguments)
        {
            try
            {
                var provider = this.providerFactory.CreateProvider(arguments);
                this.providers.Add(provider);

                return $"Successfully registered {provider.Type} Provider - {provider.Id}";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string Day()
        {
            var dayEnergyProvided = this.providers.Sum(p => p.EnergyOutput);
            this.totalEnergyStored += dayEnergyProvided;
            double dayEnergyRequired, dayMinedOre;

            if (this.mode == "Full")
            {
                dayEnergyRequired = this.harvesters.Sum(h => h.EnergyRequirement);
                dayMinedOre = this.harvesters.Sum(h => h.OreOutput);
            }
            else if (this.mode == "Half")
            {
                dayEnergyRequired = this.harvesters.Sum(h => h.EnergyRequirement) * 0.6;
                dayMinedOre = this.harvesters.Sum(h => h.OreOutput) * 0.5;
            }
            else
            {
                dayEnergyRequired = 0;
                dayMinedOre = 0;
            }

            var realDayMinedOre = 0D;

            if (this.totalEnergyStored >= dayEnergyRequired)
            {
                this.totalMinedOre += dayMinedOre;
                this.totalEnergyStored -= dayEnergyRequired;
                realDayMinedOre = dayMinedOre;
            }

            return $"A day has passed.{Environment.NewLine}" +
                   $"Energy Provided: {dayEnergyProvided}{Environment.NewLine}" +
                   $"Plumbus Ore Mined: {realDayMinedOre}";
        }

        public string Mode(List<string> arguments)
        {
            this.mode = arguments[0];

            return $"Successfully changed working mode to {this.mode} Mode";
        }

        public string Check(List<string> arguments)
        {
            var id = arguments[0];
            var unit =
                (Unit) this.harvesters.FirstOrDefault(i => i.Id == id)
                ?? this.providers.FirstOrDefault(i => i.Id == id);

            return unit != null
                ? unit.ToString()
                : $"No element found with id - {id}";
        }

        public string ShutDown()
        {
            var sb = new StringBuilder();

            sb.AppendLine("System Shutdown")
                .AppendLine($"Total Energy Stored: {(int) this.totalEnergyStored}")
                .AppendLine($"Total Mined Plumbus Ore: {(int) this.totalMinedOre}");

            return sb.ToString().Trim();
        }
    }
}