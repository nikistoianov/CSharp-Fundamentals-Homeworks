using System;
using System.Collections.Generic;
using System.Text;

public class Car : Vehicle
{
    public Car(double fuelQuantity, double fuelPerKm) : base(fuelQuantity, fuelPerKm, "Car")
    {
    }

    public void Drive(double distance)
    {
        base.Drive(distance, 0.9);
    }
}
