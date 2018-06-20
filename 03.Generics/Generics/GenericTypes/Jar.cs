using System;
using System.Collections.Generic;
using System.Text;


//implementira Generic interfeisa
public class Jar<T> : IJar<T>
{

    public readonly List<T> Items = new List<T>();

    public int Count => Items.Count;

    public void Add(T element)
    {
        this.Items.Add(element);
    }

    public T Remove()
    {
        T lastItem = this.Items[Items.Count - 1];

        this.Items.RemoveAt(Items.Count - 1);

        return lastItem;
    }

}

