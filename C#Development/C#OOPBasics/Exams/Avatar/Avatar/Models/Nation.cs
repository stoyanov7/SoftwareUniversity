namespace Avatar.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Benders;
    using Monuments;

    public class Nation
    {
        private readonly List<Bender> benders;
        private readonly List<Monument> monuments;

        public Nation()
        {
            this.benders = new List<Bender>();
            this.monuments = new List<Monument>();
        }

        public void AddBender(Bender bender) => this.benders.Add(bender);

        public void AddMonument(Monument monument) => this.monuments.Add(monument);

        public double GetTotalPoints()
        {
            var power = this.benders.Sum(x => x.GetBenderPower());
            var bonus = this.monuments.Sum(x => x.GetMonumentBonus());

            return power += power / 100 * bonus;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            if (this.benders.Count > 0)
            {
                sb.AppendLine("Benders:");
                sb.AppendLine(string.Join(Environment.NewLine, this.benders));
            }
            else
            {
                sb.AppendLine("Benders: None");
            }

            if (this.monuments.Count > 0)
            {
                sb.AppendLine("Monuments:");
                sb.AppendLine(string.Join(Environment.NewLine, this.monuments));
            }
            else
            {
                sb.AppendLine("Monuments: None");
            }

            return sb.ToString().TrimEnd();
        }

        public void KillYourself()
        {
            this.benders.Clear();
            this.monuments.Clear();
        }
    }
}