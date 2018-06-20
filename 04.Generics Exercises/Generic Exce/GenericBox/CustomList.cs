using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class CustomList<T> : IEnumerable<T>
    where T : IComparable<T>
{

    public CustomList()
    {
        this.Items = new List<T>();
    }

    private readonly List<T> Items;

    public void Add(T element)
    {
        this.Items.Add(element);
    }

    public T Remove(int index)
    {
        var currentItem = this.Items[index];
        this.Items.RemoveAt(index);
        return currentItem;
    }

    public bool Contains(T element)
    {
        bool result = this.Items.Contains(element) ? true : false;
        return result;
    }

    public void Swap(int indexOne, int indexTwo)
    {
        var temp = this.Items[indexOne];
        this.Items[indexOne] = this.Items[indexTwo];
        this.Items[indexTwo] = temp;
    }

    public int CountGreaterThan(T element)
    {
        int count = 0;

        foreach (T item in this.Items)
        {
            if (item.CompareTo(element) > 0)
            {
                count++;
            }
        }
        return count;
    }

    public T Max()
    {
        return this.Items.Max();
    }

    public T Min()
    {
        return this.Items.Min();
    }
    
    public void Sort()
    {
        this.Items.Sort();
    }
    
    public void Print()
    {
        foreach (T item in Items)
        {
            Console.WriteLine(item);
        }
    }
    
    //VAJNO !!!!! To se useshte che imame itemi i ni go implementira s tqh
    public IEnumerator<T> GetEnumerator()
    {
        return ((IEnumerable<T>)Items).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<T>)Items).GetEnumerator();
    }
}