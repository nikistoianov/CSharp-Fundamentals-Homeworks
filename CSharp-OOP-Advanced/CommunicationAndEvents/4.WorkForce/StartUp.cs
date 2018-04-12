namespace _4.WorkForce
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>();
            JobList jobs = new JobList();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var args = command.Split();
                switch (args[0])
                {
                    case "Job":
                        var jobName = args[1];
                        var hoursRequired = int.Parse(args[2]);
                        var employee = employees.First(e => e.Name == args[3]);
                        var job = new Job(jobName, hoursRequired, employee);
                        jobs.AddJob(job);
                        break;
                    case "StandardEmployee":
                        employee = new StandardEmployee(args[1]);
                        employees.Add(employee);
                        break;
                    case "PartTimeEmployee":
                        employee = new PartTimeEmployee(args[1]);
                        employees.Add(employee);
                        break;
                    case "Pass":
                        jobs.Update();
                        break;
                    case "Status":
                        jobs.Status();
                        break;
                }
            }
        }
    }
}
