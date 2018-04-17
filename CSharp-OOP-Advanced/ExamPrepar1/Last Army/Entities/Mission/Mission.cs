using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Mission : IMission
{
    public string Name { get; private set; }

    public double EnduranceRequired { get; private set; }

    public double ScoreToComplete { get; private set; }

    public double WearLevelDecrement => throw new NotImplementedException();

    public Mission(string name, double enduranceRequred, double scoreToComplete)
    {
        this.Name = name;
        this.EnduranceRequired = enduranceRequred;
        this.ScoreToComplete = scoreToComplete;
    }
}
