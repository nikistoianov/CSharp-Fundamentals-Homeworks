using System;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        var foods = Regex.Split(Console.ReadLine(), @"\s+").Where(s => s != string.Empty).Select(x => new Food(x)).ToList();
        var happiness = foods.Select(x => x.Happiness).Sum();
        var mood = new MoodFactory(happiness);
        Console.WriteLine(happiness);
        Console.WriteLine(mood.Mood);
    }
}