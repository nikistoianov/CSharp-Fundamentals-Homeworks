using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        //var company = new Company();
        var departments = new List<Department>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var employee = new Employee(Console.ReadLine());
            //company.AddEmployee(employee);

            var department = departments.FirstOrDefault(x => x.Name == employee.Department);
            if (department == null)
            {
                department = new Department(employee.Department);
                departments.Add(department);
            }
            department.Employees.Add(employee);
        }

        var depResult = departments.OrderByDescending(x => x.AverrageSalary).FirstOrDefault();
        //var departmentName = company.GetHighestAverageSalaryDep();
        Console.WriteLine($"Highest Average Salary: {depResult.Name}");
        foreach (var employee in depResult.Employees.OrderByDescending(x => x.Salary))
        {
            Console.WriteLine(employee.ToString());
        }
    }
}
