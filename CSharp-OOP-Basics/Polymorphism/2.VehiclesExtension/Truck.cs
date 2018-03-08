using System;
using System.Collections.Generic;
using System.Text;

public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelPerKm, double tankCapacity) : base(fuelQuantity, fuelPerKm, tankCapacity, "Truck")
    {
    }

    public void Drive(double distance)
    {
        base.Drive(distance, 1.6);
    }

    public override void Refuel(double fuelAmount)
    {
        base.Refuel(fuelAmount, fuelAmount * 0.05);
    }
}
