using System;
using System.Collections.Generic;
using System.Text;

public class Human
{
    private string firstName;

    public string FirstName
    {
        get { return firstName; }
        set
        {
            ValidateName(value, 3, "firstName");
            firstName = value;
        }
    }

    private string lastName;

    public string LastName
    {
        get { return lastName; }
        set
        {
            ValidateName(value, 2, "lastName");
            lastName = value;
        }
    }

    public Human(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    
    private void ValidateName(string name, int minSymbols, string argumentName)
    {
        if (name.Length <= minSymbols)
        {
            throw new ArgumentException($"Expected length at least {minSymbols + 1} symbols! Argument: {argumentName}");
        }
        if (!char.IsUpper(name[0]))
        {
            throw new ArgumentException($"Expected upper case letter! Argument: {argumentName}");
        }
    }

    public override string ToString()
    {
        var resultBuilder = new StringBuilder();
        resultBuilder.AppendLine($"First Name: {FirstName}")
            .AppendLine($"Last Name: {LastName}");

        string result = resultBuilder.ToString().TrimEnd();
        return result;
    }
}
