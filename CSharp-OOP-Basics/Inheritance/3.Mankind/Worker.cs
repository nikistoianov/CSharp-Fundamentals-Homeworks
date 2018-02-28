using System;
using System.Collections.Generic;
using System.Text;

public class Worker : Human
{
    private decimal salary;

    public decimal Salary
    {
        get { return salary; }
        set
        {
            if (value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            salary = value;
        }
    }

    private decimal workHours;

    public decimal WorkHours
    {
        get { return workHours; }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            workHours = value;
        }
    }
    
    public Worker(string firstName, string lastName, decimal salary, decimal workHours) : base(firstName, lastName)
    {
        Salary = salary;
        WorkHours = workHours;
    }

    public decimal SalaryPerHour
    {
        get => Salary / (WorkHours * 5);
    }

    public override string ToString()
    {
        var resultBuilder = new StringBuilder();
        resultBuilder.AppendLine(base.ToString())
            .AppendLine($"Week Salary: {Salary:F2}")
            .AppendLine($"Hours per day: {WorkHours:F2}")
            .AppendLine($"Salary per hour: {SalaryPerHour:F2}");

        string result = resultBuilder.ToString().TrimEnd();
        return result;
    }
}
