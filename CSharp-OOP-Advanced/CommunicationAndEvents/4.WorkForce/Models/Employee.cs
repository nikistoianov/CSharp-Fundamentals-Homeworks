namespace _4.WorkForce.Models
{
    using Contracts;

    public class Employee : IWorkable
    {
        public int WorkHoursPerWeek { get; private set; }
        public string Name { get; private set; }

        public Employee(string name, int workHoursPerWeek)
        {
            this.Name = name;
            this.WorkHoursPerWeek = workHoursPerWeek;
        }
    }
}
