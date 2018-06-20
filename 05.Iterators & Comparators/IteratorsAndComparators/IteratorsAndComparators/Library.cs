using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

//Direktno se impleentira s knigite avtomatichno !!!
public class Library : IEnumerable<Book>
{
    private List<Book> books;

    //'params' pravi ni podadenoto na masiv
    public Library(params Book[] books)
    {
        //priemame knigi
        this.books = new List<Book>(books);

        //ZADACHA 2 SORTITANE
        //this.books.Sort((a, b) => a.CompareTo(b));


        //ZADACHA 3 SORTITANE
        //      BookComparator bookComparator = new BookComparator();
        //     this.books.Sort((a,b) => bookComparator.Compare(a, b));

    }

    public IEnumerator<Book> GetEnumerator()
    {
        //suzdavame nov LibraryEnumerator s knigite, books se podava po reference
        return new LibraryIterator(books);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        //Tova e stariq GetEnumerator()
        //vrustame gorniq GetEnumerator() 
        return GetEnumerator();
    }
}




