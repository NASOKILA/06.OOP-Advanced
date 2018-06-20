using System;
using System.Collections.Generic;
using System.Text;

public class Tuple<T, U>
{
    public Tuple(T item1, U item2)
    {
        this.item1 = item1;
        this.item2 = item2;
    }

    protected T item1 { get; set; }

    protected U item2 { get; set; }

    public virtual string Print()
    {
        return $"{this.item1} -> {this.item2}";
    }

}

