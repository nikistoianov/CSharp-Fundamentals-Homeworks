using System;
using System.Collections.Generic;
using System.Linq;

public class Company
{
    public List<Employee> Employees { get; private set; }
    public HashSet<string> Departments { get; private set; }

    public Company()
    {
        Employees = new List<Employee>();
        Departments = new HashSet<string>();
    }

    public void AddEmployee(Employee employee)
    {
        Employees.Add(employee);
        Departments.Add(employee.Department);
    }

    public string GetHighestAverageSalaryDep()
    {
        var averageSalary = new Dictionary<string, double>();
        foreach (var employee in Employees)
        {
            if (averageSalary.ContainsKey(employee.Department))
            {
                averageSalary[employee.Department] += employee.Salary;
            }
            else
            {
                averageSalary.Add(employee.Department, employee.Salary);
            }
        }
        return averageSalary.OrderByDescending(x => x.Value).ToArray()[0].Key;
    }
    
}

