using System;
using System.Collections.Generic;
using System.Text;


public class BookComparator : IComparer<Book>
{
    public int Compare(Book x, Book y)
    {

        if (x.Title == y.Title)
        {
            return y.Year.CompareTo(x.Year);
            
        }

            return x.Title.CompareTo(y.Title);  
    }
}

