using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var trainers = new Dictionary<string, Trainer>();
        string command;
        while ((command = Console.ReadLine()) != "Tournament")
        {
            var args = command.Split();
            var trainerName = args[0];
            if (!trainers.ContainsKey(trainerName))
            {
                var trainer = new Trainer(args);
                trainers.Add(trainer.Name, trainer);
            }
            else
            {
                trainers[trainerName].AddPokemon(args[1], args[2], int.Parse(args[3]));
            }
        }

        while ((command = Console.ReadLine()) != "End")
        {
            foreach (var trainer in trainers)
            {
                trainer.Value.CheckElement(command);
            }
        }

        foreach (var trainer in trainers.Values.OrderByDescending(x => x.BadgesNumber))
        {
            Console.WriteLine(trainer);
        }
    }
}
