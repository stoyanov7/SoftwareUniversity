namespace KingsGambit.Models.Contracts
{
    using System;

    public interface IKillable
    {
        void KingUnderAttack(object sender, EventArgs e);
    }
}