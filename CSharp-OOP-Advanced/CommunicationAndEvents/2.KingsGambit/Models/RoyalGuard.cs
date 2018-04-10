using System;
using System.Collections.Generic;
using System.Text;

namespace _2.KingsGambit.Models
{
    public class RoyalGuard : Unit
    {
        public RoyalGuard(string name) : base(name)
        {
        }

        public override void OnKingAttack(object sender, EventArgs args)
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}
