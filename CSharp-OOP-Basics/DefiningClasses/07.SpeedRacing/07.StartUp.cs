using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var cars = new Dictionary<string, Car>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var car = new Car(Console.ReadLine());
            cars.Add(car.Model, car);
        }

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            var splitLine = command.Split();
            var carModel = splitLine[1];
            var driveDistance = double.Parse(splitLine[2]);

            if (!cars[carModel].DriveCar(driveDistance))
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car.Value.ToString());
        }
    }
}
