namespace Avatar.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Models;
    using Models.Benders;
    using Models.Monuments;

    public class NationsBuilder
    {
        private readonly Dictionary<string, Nation> nations;
        private readonly List<string> wars;

        public NationsBuilder()
        {
            this.nations = new Dictionary<string, Nation>
            {
                { "Air", new Nation() },
                { "Earth", new Nation() },
                { "Fire", new Nation() },
                { "Water", new Nation() }
            };

            this.wars = new List<string>();
        }

        public void AssignBender(List<string> benderArgs)
        {
            var type = benderArgs[0];
            var name = benderArgs[1];
            var power = int.Parse(benderArgs[2]);
            var secondParam = double.Parse(benderArgs[3]);

            switch (type)
            {
                case "Air":
                    var airBender = new AirBender(name, power, secondParam);
                    this.nations[type].AddBender(airBender);
                    break;
                case "Earth":
                    var earthBender = new EarthBender(name, power, secondParam);
                    this.nations[type].AddBender(earthBender);
                    break;
                case "Fire":
                    var fireBender = new FireBender(name, power, secondParam);
                    this.nations[type].AddBender(fireBender);
                    break;
                case "Water":
                    var waterBender = new WaterBender(name, power, secondParam);
                    this.nations[type].AddBender(waterBender);
                    break;
            }
        }

        public void AssignMonument(List<string> monumentArgs)
        {
            var type = monumentArgs[0];
            var name = monumentArgs[1];
            var affinity = int.Parse(monumentArgs[2]);

            switch (type)
            {
                case "Air":
                    var airMonument = new AirMonument(name, affinity);
                    this.nations[type].AddMonument(airMonument);
                    break;
                case "Earth":
                    var earthMonument = new EarthMonument(name, affinity);
                    this.nations[type].AddMonument(earthMonument);
                    break;
                case "Fire":
                    var fireMonument = new FireMonument(name, affinity);
                    this.nations[type].AddMonument(fireMonument);
                    break;
                case "Water":
                    var waterMonument = new WaterMonument(name, affinity);
                    this.nations[type].AddMonument(waterMonument);
                    break;
            }
        }

        public string GetStatus(string nationsType)
        {
            return $"{nationsType} Nation{Environment.NewLine}{this.nations[nationsType].ToString()}";
        }

        public void IssueWar(string nationsType)
        {
            this.wars.Add(nationsType);
            var winner = this.nations.Max(n => n.Value.GetTotalPoints());

            foreach (var nation in this.nations)
            {
                if (nation.Value.GetTotalPoints() != winner)
                {
                    nation.Value.KillYourself();
                }
            }
        }

        public string GetWarsRecord()
        {
            var sb = new StringBuilder();

            for (var i = 0; i < this.wars.Count; i++)
            {
                sb.AppendLine($"War {i + 1} issued by {this.wars[i]}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}