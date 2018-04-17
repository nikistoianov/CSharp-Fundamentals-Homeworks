using System;
using System.Linq;
using System.Reflection;

namespace Last_Army.Core
{
    public class SoldiersFactory : ISoldierFactory
    {
        public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
        {
            Type soldierType = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == soldierTypeName);

            return (ISoldier)Activator.CreateInstance(soldierType, name, age, experience, endurance);
        }
    }
}