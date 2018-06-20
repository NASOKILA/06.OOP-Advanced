using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class LibraryIterator : IEnumerator<Book>
{

    private readonly List<Book> books;
    private int currentIndex;   //Trqbva ni index

    //vrushta knigata na tekushtiq index
    public Book Current => this.books[currentIndex];

    //kazvame mu che e kato gornoto current, PONQKOGA SE NALAGA DA GO KASTNEM TUKA
    object IEnumerator.Current => Current;

    
    public LibraryIterator(IEnumerable<Book> books)
    {
        Reset();
        //zapazvame knigite koito shte iterirame
        this.books = new List<Book>(books);
    }

    public void Dispose() { }

    public bool MoveNext()
    {
        //uvelichavame indexa
        return ++currentIndex < this.books.Count; //vrushtame dali e > ot broq
    }

    public void Reset()
    {
        //indexa se setva ot konstruktura takache nqma da go polzvame
        this.currentIndex = -1;
    }
    
}

