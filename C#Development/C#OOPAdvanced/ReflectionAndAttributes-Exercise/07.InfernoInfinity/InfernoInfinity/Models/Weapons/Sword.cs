namespace InfernoInfinity.Models.Weapons
{
    using System.Collections.Generic;
    using Gems;

    public class Sword : Weapon
    {
        public Sword(string name) 
            : base(name, 4, 6)
        {
            this.SocketWithGems = new List<IGem>(3);
        }
    }
}