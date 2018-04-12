namespace _2.KingsGambit.Models
{
    using _2.KingsGambit.Contracts;
    using System;

    public abstract class Unit : INameable
    {
        private int hitsTaken;
        protected bool isDead;

        public string Name { get; private set; }
        public int HitsNumber { get; private set; }

        public Unit(string name, int hitsNumber)
        {
            this.Name = name;
            this.HitsNumber = hitsNumber;
            this.isDead = false;
        }

        public abstract void OnKingAttack(object sender, EventArgs args);

        public void TakeHit()
        {
            this.hitsTaken++;
            if (this.hitsTaken >= this.HitsNumber)
                this.isDead = true;
        }
    }
}
