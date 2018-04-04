namespace InfernoInfinity.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Factories;
    using Factories.Contracts;
    using Models.Weapons;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IList<IWeapon> weapons;
        private readonly IWeaponFactory weaponFactory;
        private readonly IGemFactory gemFactory;

        public CommandInterpreter()
        {
            this.weapons = new List<IWeapon>();
            this.weaponFactory = new WeaponFactory();
            this.gemFactory = new GemFactory();
        }

        public void Create(IEnumerable<string> line)
        {
            var weapon = this.weaponFactory.CreateWeapon(line.Skip(1).ToList());
            this.weapons.Add(weapon);
        }

        public void Add(IReadOnlyList<string> line)
        {
            var weaponName = line[1];
            var socketIndex = int.Parse(line[2]);
            var gemInfo = line[3];
            var newGem = this.gemFactory.CreateGem(gemInfo);

            this.weapons
                .First(x => x.Name.Equals(weaponName))
                .SocketWithGems
                .Insert(socketIndex, newGem);
        }

        public void Remove(IReadOnlyList<string> line)
        {
            var weaponName = line[1];
            var socketIndex = int.Parse(line[2]);

            this.weapons
                .First(x => x.Name.Equals(weaponName))
                .SocketWithGems
                .RemoveAt(socketIndex);
        }

        public void Print(IReadOnlyList<string> line)
        {
            var weaponName = line[1];
            this.weapons
                .First(x => x.Name.Equals(weaponName))
                .IncreaseDamageByGems();

            Console.WriteLine(this.weapons.First(x => x.Name.Equals(weaponName)).ToString());
        }
    }
}