using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var cars = new List<Car>();
        var engines = new Dictionary<string, Engine>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var engine = new Engine(Console.ReadLine());
            engines.Add(engine.Model, engine);
        }

        n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var car = new Car(Console.ReadLine(), engines);
            cars.Add(car);            
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }

    }
}
