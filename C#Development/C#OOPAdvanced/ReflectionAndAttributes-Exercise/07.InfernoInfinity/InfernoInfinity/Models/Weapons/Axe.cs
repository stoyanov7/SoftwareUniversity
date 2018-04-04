namespace InfernoInfinity.Models.Weapons
{
    using System.Collections.Generic;
    using Gems;

    public class Axe : Weapon
    {
        public Axe(string name) 
            : base(name, 5, 10)
        {
            this.SocketWithGems = new List<IGem>(4);
        }
    }
}