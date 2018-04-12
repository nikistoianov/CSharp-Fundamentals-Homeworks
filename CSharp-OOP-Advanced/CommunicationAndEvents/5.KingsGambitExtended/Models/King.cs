namespace _2.KingsGambit.Models
{
    using System;
    using _2.KingsGambit.Contracts;

    public class King : Unit, IAttackable
    {
        public King(string name) : base(name, int.MaxValue) { }

        public event AttackEventHandler AttackTrigger;

        public void Attack()
        {
            if (AttackTrigger != null)
            {
                AttackTrigger.Invoke(this, new EventArgs());
            }
        }

        public override void OnKingAttack(object sender, EventArgs args)
        {
            Console.WriteLine($"King {this.Name} is under attack!");
        }
    }
}
