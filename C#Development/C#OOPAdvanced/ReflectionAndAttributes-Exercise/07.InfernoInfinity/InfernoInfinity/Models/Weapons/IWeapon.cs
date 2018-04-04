namespace InfernoInfinity.Models.Weapons
{
    using System.Collections.Generic;
    using Gems;

    public interface IWeapon
    {
        string Name { get; set; }

        int MinDamage { get; set; }

        int MaxDamage { get; set; }

        IList<IGem> SocketWithGems { get; set; }

        void IncreaseDamageByGems();
        void IncreaseDamageByRarity(int increaseBy);
        string ToString();
    }
}