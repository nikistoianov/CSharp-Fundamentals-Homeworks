using System;
using System.Collections.Generic;
using System.Text;

public class Box<T>
{
    private T val;

    public Box(T val)
    {
        this.val = val;
    }

    public override string ToString()
    {
        return $"{this.val.GetType().ToString()}: {this.val}";
    }
}
