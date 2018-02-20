using System;
using System.Collections.Generic;
using System.Linq;

public class Trainer
{
    public string Name { get; set; }
    public int BadgesNumber { get; set; }
    public List<Pokemon> Pokemons { get; set; }

    public Trainer(string[] trainerArgs)
    {
        Name = trainerArgs[0];
        Pokemons = new List<Pokemon>();
        AddPokemon(trainerArgs[1], trainerArgs[2], int.Parse(trainerArgs[3]));
        //var pokemon = new Pokemon(trainerArgs[1], trainerArgs[2], int.Parse(trainerArgs[3]));
        //Pokemons.Add(pokemon);
    }

    public void AddPokemon(string name, string element, int health)
    {
        var pokemon = new Pokemon(name, element, health);
        Pokemons.Add(pokemon);
    }

    public bool ContainsPokemon(string element)
    {
        return Pokemons.Where(x => x.Element == element).ToArray().Length > 0;
    }

    public void CheckElement(string element)
    {
        if (ContainsPokemon(element))
        {
            BadgesNumber++;
        }
        else
        {
            foreach (var pokemon in Pokemons)
            {
                pokemon.Health -= 10;
            }
            Pokemons = Pokemons.Where(x => x.Health >= 0).ToList();
        }
    }

    public override string ToString()
    {
        return $"{Name} {BadgesNumber} {Pokemons.Count}";
    }
}
