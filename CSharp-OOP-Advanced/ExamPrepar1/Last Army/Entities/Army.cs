using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Army : IArmy
{
    public IReadOnlyList<ISoldier> Soldiers => throw new NotImplementedException();

    public void AddSoldier(ISoldier soldier)
    {
        throw new NotImplementedException();
    }

    public void RegenerateTeam(string soldierType)
    {
        throw new NotImplementedException();
    }
}
