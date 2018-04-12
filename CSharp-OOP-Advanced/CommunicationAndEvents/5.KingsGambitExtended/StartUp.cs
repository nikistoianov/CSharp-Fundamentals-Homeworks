namespace _2.KingsGambit
{
    using Models;
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var king = new King(Console.ReadLine());
            king.AttackTrigger += king.OnKingAttack;

            var army = new List<Unit>();
            foreach (var soldier in Console.ReadLine().Split())
            {
                var royalGuard = new RoyalGuard(soldier);
                king.AttackTrigger += royalGuard.OnKingAttack;
                army.Add(royalGuard);
            }
            foreach (var soldier in Console.ReadLine().Split())
            {
                var footman = new Footman(soldier);
                king.AttackTrigger += footman.OnKingAttack;
                army.Add(footman);
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                if (command == "Attack King")
                    king.Attack();
                else
                {
                    var soldierName = command.Split()[1];
                    var soldierToRemove = army.First(x => x.Name == soldierName);
                    soldierToRemove.TakeHit();
                    //army.Remove(soldierToRemove);

                    //king.AttackTrigger -= soldierToRemove.OnKingAttack;
                }
            }            
        }
    }
}
