namespace KingsGambit.Models.Abstract
{
    using System;
    using Contracts;

    public abstract class Soldier : ISoldier
    {
        protected Soldier(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public abstract void KingUnderAttack(object sender, EventArgs e);
    }
}