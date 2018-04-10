namespace _2.KingsGambit.Models
{
    using _2.KingsGambit.Contracts;
    using System;

    public abstract class Unit : INameable
    {
        public string Name { get; private set; }

        public Unit(string name)
        {
            this.Name = name;
        }

        public abstract void OnKingAttack(object sender, EventArgs args);

    }
}
