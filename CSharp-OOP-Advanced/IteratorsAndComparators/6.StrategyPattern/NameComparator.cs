using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class NameComparator : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        var result = x.Name.Length.CompareTo(y.Name.Length);
        if (result != 0)
        {
            return result;
        }
        return char.ToLower(x.Name[0]).CompareTo(char.ToLower(y.Name[0]));
    }
}
