﻿namespace Avatar.Models.Monuments
{
    public class WaterMonument : Monument
    {
        public WaterMonument(string name, int waterAffinity)
            : base(name)
        {
            this.WaterAffinity = waterAffinity;
        }

        public int WaterAffinity { get; private set; }

        public override double GetMonumentBonus()
        {
            return this.WaterAffinity;
        }

        public override string ToString()
        {
            return $"{base.ToString()} Water Affinity: {this.WaterAffinity}";
        }
    }
}