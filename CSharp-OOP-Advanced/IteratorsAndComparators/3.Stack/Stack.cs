using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Stack<T> : IEnumerable<T>
{
    private List<T> list;
    private int index;

    public Stack()
    {
        this.list = new List<T>();
        index = 0;
    }

    public void Push(T element)
    {
        this.list.Add(element);
    }

    public T Pop()
    {
        T element = this.list.LastOrDefault();
        if (element == null)
            throw new ArgumentException("No elements");
        this.list.Remove(element);
        return element;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = list.Count - 1; i >= 0; i--)
        {
            yield return list[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
