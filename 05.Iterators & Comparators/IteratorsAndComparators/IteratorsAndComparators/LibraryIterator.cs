using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class LibraryIterator : IEnumerator<Book>
{
    private readonly List<Book> books;
	
    private int currentIndex;  

    public Book Current => this.books[currentIndex];

    object IEnumerator.Current => Current;

    public LibraryIterator(IEnumerable<Book> books)
    {
        Reset();
        this.books = new List<Book>(books);
    }

    public void Dispose() { }

    public bool MoveNext()
    {
        return ++currentIndex < this.books.Count; 
    }

    public void Reset()
    {
        this.currentIndex = -1;
    }
}