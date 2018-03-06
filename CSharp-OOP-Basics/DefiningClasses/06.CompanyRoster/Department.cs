using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Department
{
    public string Name { get; set; }
    public List<Employee> Employees { get; set; }

    public Department(string name)
    {
        Name = name;
        Employees = new List<Employee>();
    }

    public double AverrageSalary => Employees.Select(x => x.Salary).Average();
}