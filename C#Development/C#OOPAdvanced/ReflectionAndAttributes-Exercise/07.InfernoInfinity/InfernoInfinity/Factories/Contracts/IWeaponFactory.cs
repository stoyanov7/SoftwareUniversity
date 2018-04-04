namespace InfernoInfinity.Factories.Contracts
{
    using System.Collections.Generic;
    using Models.Weapons;

    public interface IWeaponFactory
    {
        IWeapon CreateWeapon(IList<string> args);
    }
}