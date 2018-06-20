using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class Book : IComparable<Book>
{

    //kato napishem 'params' dori i da ne podadem masiv ot stringove, ako podadem samo stringove ni gi slaga v masiv
    public Book(string title, int year, params string[] authors)
    {
        this.Title = title;
        this.Year = year;
        this.Authors = new List<string>(authors);
    }

    public string Title { get; private set; }

    public int Year { get; private set; }

    public List<string> Authors { get; private set; }

    public int CompareTo(Book other)
    {

        int result = this.Year.CompareTo(other.Year);
        if (result == 0)
        {
            return this.Title.CompareTo(other.Title);
        }
        return result;

    }

    public override string ToString()
    {
        return $"{this.Title} - {this.Year}";
    }

}

