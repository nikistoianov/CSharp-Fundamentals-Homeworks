using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    public string Model { get; set; }
    public double FuelAmount { get; set; }
    public double FuelConsumption { get; set; }
    public double DistanceTraveled { get; set; }

    public Car(string carLine)
    {
        var carArgs = carLine.Split();
        Model = carArgs[0];
        FuelAmount = double.Parse(carArgs[1]);
        FuelConsumption = double.Parse(carArgs[2]);
        DistanceTraveled = 0;
    }

    public bool DriveCar(double driveDistance)
    {
        double fuelNeeded = FuelConsumption * driveDistance;
        if (fuelNeeded <= FuelAmount)
        {
            FuelAmount -= fuelNeeded;
            DistanceTraveled += driveDistance;
            return true;
        }
        else
        {
            return false;
        }
    }

    public override string ToString()
    {
        return $"{Model} {FuelAmount:F2} {DistanceTraveled}";
    }
}
