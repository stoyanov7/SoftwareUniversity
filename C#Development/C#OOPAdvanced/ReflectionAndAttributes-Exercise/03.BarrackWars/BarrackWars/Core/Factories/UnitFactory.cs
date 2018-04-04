namespace BarrackWars.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        private const string NamespaceAsString = "BarrackWars.Models";

        public IUnit CreateUnit(string unitType)
        {
            var classType = Type.GetType($"{NamespaceAsString}.{unitType}");

            if (classType == null)
            {
                return null;
            }

            return (IUnit)Activator.CreateInstance(classType);
        }
    }
}
