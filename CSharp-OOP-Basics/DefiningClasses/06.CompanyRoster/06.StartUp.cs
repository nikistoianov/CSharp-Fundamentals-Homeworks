using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var company = new Company();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var employee = new Employee(Console.ReadLine());
            company.AddEmployee(employee);
        }

        var departmentName = company.GetHighestAverageSalaryDep();
        Console.WriteLine($"Highest Average Salary: {departmentName}");
        foreach (var employee in company.Employees.Where(x => x.Department == departmentName).OrderByDescending(x => x.Salary))
        {
            Console.WriteLine(employee.ToString());
        }
    }
}
