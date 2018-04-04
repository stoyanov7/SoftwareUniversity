namespace InfernoInfinity.Models.Gems
{
    public abstract class Gem : IGem
    {
        protected Gem(int strenght, int agility, int vitality)
        {
            this.Strenght = strenght;
            this.Agility = agility;
            this.Vitality = vitality;
        }

        public int Strenght { get; set; }

        public int Agility { get; set; }

        public int Vitality { get; set; }
    }
}