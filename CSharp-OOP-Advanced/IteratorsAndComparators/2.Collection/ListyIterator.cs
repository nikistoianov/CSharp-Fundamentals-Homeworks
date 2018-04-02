﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class ListyIterator<T>:IEnumerable<T>
{
    private List<T> list;
    private int index;

    public ListyIterator(List<T> list)
    {
        this.list = list;
        index = 0;
    }

    public bool Move()
    {
        if (index < list.Count - 1)
        {
            index++;
            return true;
        }
        return false;
    }

    public bool HasNext()
    {
        return (index < list.Count - 1);
    }

    public void Print()
    {
        if (list.Count == 0)
        {
            throw new ArgumentException("Invalid Operation!");
        }
        Console.WriteLine(list[index]);
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < list.Count; i++)
        {
            yield return list[i];
        }        
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
