using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Student : Human
{

    private string facultyNumber;

    public string FacultyNumber
    {
        get { return facultyNumber; }
        set
        {
            if (value.Length < 5 || value.Length > 10 || !value.All(char.IsLetterOrDigit))
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            facultyNumber = value;
        }
    }

    public Student(string firstName, string lastName, string facultyNumber) : base(firstName, lastName)
    {
        FacultyNumber = facultyNumber;
    }

    public override string ToString()
    {
        var resultBuilder = new StringBuilder();
        resultBuilder.AppendLine(base.ToString())
            .AppendLine($"Faculty number: {FacultyNumber}");

        string result = resultBuilder.ToString().TrimEnd();
        return result;
    }
}
