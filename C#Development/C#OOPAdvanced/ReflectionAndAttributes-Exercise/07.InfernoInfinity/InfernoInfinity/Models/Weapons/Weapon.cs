namespace InfernoInfinity.Models.Weapons
{
    using System.Collections.Generic;
    using System.Linq;
    using Gems;

    public abstract class Weapon : IWeapon
    {
        protected Weapon(string name, int minDamage, int maxDamage)
        {
            this.Name = name;
            this.MinDamage = minDamage;
            this.MaxDamage = maxDamage;
        }

        public string Name { get; set; }

        public int MinDamage { get; set; }

        public int MaxDamage { get; set; }

        public IList<IGem> SocketWithGems { get; set; }

        public void IncreaseDamageByRarity(int increaseBy)
        {
            this.MinDamage *= increaseBy;
            this.MaxDamage *= increaseBy;
        }

        public void IncreaseDamageByGems()
        {
            var addToMinDmg = this.SocketWithGems.Sum(x => x.Strenght) * 2
                              + this.SocketWithGems.Sum(x => x.Agility);

            var addToMaxDmg = this.SocketWithGems.Sum(x => x.Strenght) * 3
                              + this.SocketWithGems.Sum(x => x.Agility) * 4;

            this.MinDamage += addToMinDmg;
            this.MaxDamage += addToMaxDmg;
        }

        public override string ToString()
        {
            var sumStrenght = this.SocketWithGems.Sum(x => x.Strenght);
            var sumAgility = this.SocketWithGems.Sum(x => x.Agility);
            var sumVitality = this.SocketWithGems.Sum(x => x.Vitality);

            return $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{sumStrenght} Strength, +{sumAgility} Agility, +{sumVitality} Vitality";
        }

    }
}