namespace BarrackWars.Data
{
    using System;
    using Contracts;
    using System.Collections.Generic;
    using System.Text;

    public class UnitRepository : IRepository
    {
        private readonly IDictionary<string, int> amountOfUnits;

        public UnitRepository()
        {
            this.amountOfUnits = new SortedDictionary<string, int>();
        }

        public string Statistics
        {
            get
            {
                var sb = new StringBuilder();
                foreach (var entry in this.amountOfUnits)
                {
                    sb.AppendLine($"{entry.Key} -> {entry.Value}");
                }

                return sb.ToString().Trim();
            }
        }

        public void AddUnit(IUnit unit)
        {
            var unitType = unit.GetType().Name;

            if (!this.amountOfUnits.ContainsKey(unitType))
            {
                this.amountOfUnits.Add(unitType, 0);
            }

            this.amountOfUnits[unitType]++;
        }

        public void RemoveUnit(string unitType)
        {
            if (!this.amountOfUnits.ContainsKey(unitType))
            {
                throw new InvalidOperationException("No such units in repository.");
            }

            if (this.amountOfUnits[unitType] == 0)
            {
                throw new InvalidOperationException("No such units in repository.");
            }

            this.amountOfUnits[unitType]--;
        }
    }
}
