using System;
using System.Collections.Generic;
using System.Text;

namespace _2.KingsGambit.Models
{
    public class RoyalGuard : Unit
    {
        public RoyalGuard(string name) : base(name, 3) { }        

        public override void OnKingAttack(object sender, EventArgs args)
        {
            if (!this.isDead)
                Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}
