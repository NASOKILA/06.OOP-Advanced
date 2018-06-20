using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class ListIterator 
{

    private List<string> collection;

    private int currentIndex;

    public ListIterator(params string[] collection)
    {
        this.currentIndex = 0;

        this.collection = 
            collection.ToList()
            ?? throw new ArgumentNullException();
    }
    
    public bool Move()
    {
        if (this.HasNext())
        {
            this.currentIndex++;
            return true;
        }

        return false;
    }

    public bool HasNext()
    {
        if (this.currentIndex >= this.collection.Count-1)
            return false;

        return true;
    }

    public void Print()
    {
        if (this.collection.Count == 0)
            throw new InvalidOperationException("Invalid Operation!");

        Console.WriteLine(this.collection[this.currentIndex]);
    }

}

