using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class ListyIterator<T> : IEnumerable<T>
{
    public ListyIterator(List<T> collection)
    {
        this.collection = collection;
        this.currentIndex = 0;
    }

    private int currentIndex;

    private List<T> collection { get; set; }

    public bool Move()
    {
        if (this.HasNext())
        {
            currentIndex++;
            return true;
        }
        return false;
    }

    public bool HasNext()
    {
        if (this.currentIndex == this.collection.Count-1)
        {
            return false;
        }
        return true;
    }

    public void Print()
    {
        if (this.collection.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        T element = this.collection[this.currentIndex];
        Console.WriteLine(element);

    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.collection.Count; i++)
        {
            yield return this.collection[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public void PrintAll()
    {

        if (this.collection.Count == 0)
            throw new InvalidOperationException("Invalid Operation!");
        
        var sb = new StringBuilder();

        foreach (var item in this.collection)
            sb.Append($"{item} ");
        
        Console.WriteLine(sb.ToString().Trim());

    }

}

/*
Create 1 2
Move
Move
Move
HasNext
END
 
     
*/
