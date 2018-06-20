using System;
using System.Collections.Generic;
using System.Text;


public class Box<T>
{

    public Box()
    {
        this.Items = new List<T>();
    }

    private readonly List<T> Items;

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

