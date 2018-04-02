﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Person : IComparable<Person>
{
    private string name;
    private int age;
    private string town;

    public Person(string name, int age, string town)
    {
        this.name = name;
        this.age = age;
        this.town = town;
    }

    public int CompareTo(Person other)
    {
        var result = this.name.CompareTo(other.name);
        if (result != 0)
        {
            return result;
        }
        result = this.age.CompareTo(other.age);
        if (result != 0)
        {
            return result;
        }
        return this.town.CompareTo(other.town);
    }
}