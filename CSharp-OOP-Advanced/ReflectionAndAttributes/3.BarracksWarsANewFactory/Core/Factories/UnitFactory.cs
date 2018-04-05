namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            //TODO: implement for Problem 3
            var type = Type.GetType("_03BarracksFactory.Models.Units." + unitType);
            var unit = (IUnit)Activator.CreateInstance(type, true);
            return unit;
        }
    }
}
