using System;
using System.Collections.Generic;
using System.Text;

public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelPerKm) : base(fuelQuantity, fuelPerKm, "Truck")
    {
    }

    public void Drive(double distance)
    {
        base.Drive(distance, 1.6);
    }

    public override void Refuel(double fuelAmount)
    {
        base.Refuel(fuelAmount * 0.95);
    }
}
