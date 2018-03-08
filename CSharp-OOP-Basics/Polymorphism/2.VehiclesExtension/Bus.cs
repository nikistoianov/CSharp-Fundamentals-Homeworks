using System;
using System.Collections.Generic;
using System.Text;

public class Bus : Vehicle
{
    public Bus(double fuelQuantity, double fuelPerKm, double tankCapacity) : base(fuelQuantity, fuelPerKm, tankCapacity, "Bus")
    {
    }

    public void Drive(double distance, bool withPeople)
    {
        double consumptionIncrease = withPeople ? 1.4 : 0;
        base.Drive(distance, consumptionIncrease);
    }
}
