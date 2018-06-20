using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class NameComparator : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        int lengthX = x.name.Length;

        int lengthY = y.name.Length;

        int lengthCompare = lengthX.CompareTo(lengthY);
        if (lengthCompare == 0)
        {
            char firstLetterX = Char.ToLower(x.name.First()); 
            char firstLetterY = Char.ToLower(y.name.First());

            return firstLetterX.CompareTo(firstLetterY);
        }

        return lengthCompare;
    }
}

