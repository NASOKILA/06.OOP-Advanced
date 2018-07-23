using System;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    class Program
    {
        static void Main(string[] args)
        {       
            Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
            Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            Book bookThree = new Book("The Documents in the Case", 1930);

            Library libraryOne = new Library();
            Library libraryTwo = new Library(bookOne, bookTwo, bookThree);

            List<Book> books = new List<Book> { bookOne, bookTwo, bookThree };

            var enumerator = libraryTwo.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }

            foreach (var book in libraryTwo)
            {
                Console.WriteLine(book.ToString());
            }
        }

        public static void Test(params string[] arr) {
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}