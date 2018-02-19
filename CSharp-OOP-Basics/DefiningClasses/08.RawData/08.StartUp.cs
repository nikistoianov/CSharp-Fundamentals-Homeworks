using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var cars = new List<Car>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var car = new Car(Console.ReadLine());
            cars.Add(car);
        }

        string command = Console.ReadLine();
        if (command == "fragile")
        {
            foreach (var car in cars.Where(x => x.CarCargo.Type == "fragile" && x.Tires.Where(y => y.Pressure < 1).ToArray().Length > 0))
            {
                Console.WriteLine(car.Model);
            }
        }
        else if (command == "flamable")
        {
            foreach (var car in cars.Where(x => x.CarCargo.Type == "flamable" && x.CarEngine.Power > 250))
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
