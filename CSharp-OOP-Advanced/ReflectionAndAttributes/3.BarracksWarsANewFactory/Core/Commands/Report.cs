using System;
using System.Collections.Generic;
using System.Text;

namespace _03BarracksFactory.Core.Commands
{
    using Contracts;
    public class Report : Command
    {
        public Report(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            return this.ReportCommand(Data);
        }

        private string ReportCommand(string[] data)
        {
            string output = this.Repository.Statistics;
            return output;
        }
    }
}
