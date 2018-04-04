namespace InfernoInfinity.Models.Weapons
{
    using System.Collections.Generic;
    using Gems;

    public class Knife : Weapon
    {
        public Knife(string name)
            : base(name, 3, 4)
        {
            this.SocketWithGems = new List<IGem>(2);
        }
    }
}