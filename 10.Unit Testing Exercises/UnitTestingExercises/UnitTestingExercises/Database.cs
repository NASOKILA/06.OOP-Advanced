using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Database
{

    private int[] storage;

    public Database()
    {
        this.storage = new int[16];
    }

    public Database(params int[] args)
        :this()
    {

        if (args.Length > 16)
            throw new InvalidOperationException("Size bigger than 16 integers!");
        
        for(int i = 0; i < args.Length; i++)
            storage[i] = args[i];
    }

    public void Add(int item)
    {
        if (item != 0)
        {
            bool itemAdded = false;

            for (int i = 0; i < this.storage.Length; i++)
            {
                if (storage[i] == 0)
                {
                    storage[i] = item;
                    itemAdded = true;
                    break;
                }
            }

            if (!itemAdded)
                throw new InvalidOperationException("Storage is full!");
        }
    }

    public void Remove()
    {
        bool itemRemoved = false;

        for (int i = this.storage.Length-1; i >= 0; i--)
        {
            if (this.storage[i] != default(int))
            {
                this.storage[i] = default(int);
                itemRemoved = true;
                break;
            }
        }
        if (!itemRemoved)
            throw new InvalidOperationException("Storage is Empty!");
    }

    public int[] Fetch()
    {
        int count = this.storage.Where(l => l != default(int)).Count();
        int[] resultArray = new int[count];

        for(int i = 0; i < this.storage.Length; i++)
        {
            if (this.storage[i] != default(int))
                resultArray[i] = this.storage[i]; 
        }

        return resultArray;
    }

}
