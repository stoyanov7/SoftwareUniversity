namespace InfernoInfinity.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Enums;
    using Models.Weapons;

    public class WeaponFactory : IWeaponFactory
    {
        public IWeapon CreateWeapon(IList<string> args)
        {
            var rarityType = args[0].Split().ToList();
            var rarity = rarityType[0];
            var type = rarityType[1];
            var weaponName = args[1];
            var increaseDamageBy = 0;

            var enumRarity = (Rarity)Enum.Parse(typeof(Rarity), rarity);

            switch (enumRarity)
            {
                case Rarity.Common:
                    increaseDamageBy = 1;
                    break;
                case Rarity.Uncommon:
                    increaseDamageBy = 2;
                    break;
                case Rarity.Rare:
                    increaseDamageBy = 3;
                    break;
                case Rarity.Epic:
                    increaseDamageBy = 5;
                    break;
            }

            IWeapon weapon = null;

            switch (type)
            {
                case "Axe":
                    weapon = new Axe(weaponName);
                    break;
                case "Sword":
                    weapon = new Sword(weaponName);
                    break;
                case "Knife":
                    weapon = new Knife(weaponName);
                    break;
            }

            weapon?.IncreaseDamageByRarity(increaseDamageBy);

            return weapon;
        }
    }
}