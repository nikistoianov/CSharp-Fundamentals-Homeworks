using System;
using System.Collections.Generic;
using System.Text;

namespace _4.WorkForce.Models
{
    public class PartTimeEmployee : Employee
    {
        public PartTimeEmployee(string name) : base(name, workHoursPerWeek: 20) { }
    }
}
