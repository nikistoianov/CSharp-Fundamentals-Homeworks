using System;
using System.Collections.Generic;
using System.Text;

namespace _03BarracksFactory.Core.Commands
{
    using Contracts;
    public class Retire : Command 
    {
        public Retire(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string unitType = Data[1];
            this.Repository.RemoveUnit(unitType);
            string output = unitType + " retired!";
            return output;
        }
    }
}
