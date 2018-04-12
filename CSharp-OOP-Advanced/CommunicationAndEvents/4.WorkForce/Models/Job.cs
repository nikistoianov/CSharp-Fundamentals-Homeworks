using System;
using System.Collections.Generic;
using System.Text;

namespace _4.WorkForce.Models
{
    public delegate void JobCompleteHandler(Job job);
    public class Job
    {
        public event JobCompleteHandler JobComplete;
        private string name;
        private int hoursOfWorkRequired;
        private Employee employee;

        public Job(string name, int hoursOfWorkRequired, Employee employee)
        {
            this.hoursOfWorkRequired = hoursOfWorkRequired;
            this.name = name;
            this.employee = employee;
        }

        public void Update()
        {
            hoursOfWorkRequired -= employee.WorkHoursPerWeek;

            if (hoursOfWorkRequired <= 0)
            {
                Console.WriteLine($"{this.GetType().Name} {this.name} done!");
                this.JobComplete.Invoke(this);
            }
        }

        public void Status()
        {
            var result = $"{this.GetType().Name}: {this.name} Hours Remaining: {this.hoursOfWorkRequired}";
            Console.WriteLine(result);
        }
    }
}
