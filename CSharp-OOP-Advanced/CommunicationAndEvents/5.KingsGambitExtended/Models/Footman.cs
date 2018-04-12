using System;
using System.Collections.Generic;
using System.Text;

namespace _2.KingsGambit.Models
{
    public class Footman : Unit
    {
        public Footman(string name) : base(name, 2) { }

        public override void OnKingAttack(object sender, EventArgs args)
        {
            if (!this.isDead)
                Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}
