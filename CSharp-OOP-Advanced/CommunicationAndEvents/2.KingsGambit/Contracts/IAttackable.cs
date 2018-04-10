using System;
using System.Collections.Generic;
using System.Text;

namespace _2.KingsGambit.Contracts
{
    public delegate void AttackEventHandler(object sender, EventArgs args);

    interface IAttackable
    {
        event AttackEventHandler AttackTrigger;
        void Attack();
    }
}
