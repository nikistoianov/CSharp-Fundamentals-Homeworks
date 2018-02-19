﻿using System;
using System.Collections.Generic;
using System.Linq;


public class Family
{
    public List<Person> People { get; private set; }

    public Family()
    {
        People = new List<Person>();
    }

    public void AddMember(Person member)
    {
        People.Add(member);
    }

    public Person GetOldestMember()
    {
        return People.OrderByDescending(x => x.Age).ToArray()[0];
    }
}

