using System;
using System.Collections.Generic;
using System.Text;

public class Employee
{
    public string Name { get; set; }
    public double Salary { get; set; }
    public string Position { get; set; }
    public string Department { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }

    public Employee(string name, double salary, string position, string department)
    {
        Name = name;
        Salary = salary;
        Position = position;
        Department = department;
        Email = "n/a";
        Age = -1;
    }

    public Employee(string[] employeeArgs) : this(employeeArgs[0], double.Parse(employeeArgs[1]), employeeArgs[2], employeeArgs[3])
    {
        if (employeeArgs.Length > 4)
        {
            if (employeeArgs[4].Contains("@"))
            {
                Email = employeeArgs[4];
            }
            else
            {
                Age = int.Parse(employeeArgs[4]);
            }
        }
            
        if (employeeArgs.Length > 5)
        {
            if (employeeArgs[5].Contains("@"))
            {
                Email = employeeArgs[5];
            }
            else
            {
                Age = int.Parse(employeeArgs[5]);
            }
        }
    }

    public Employee(string employeeLine) : this(employeeLine.Split()) { }

    public override string ToString()
    {
        return $"{Name} {Salary:F2} {Email} {Age}";
    }
}
