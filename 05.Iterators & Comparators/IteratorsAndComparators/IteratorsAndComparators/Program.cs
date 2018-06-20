using System;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             STE RAZGLEDAME:
                Iterators:
                    IEnumerable<T> interface
             
                    yeald   //return 
             
                    params   //
             

                Comparators:
                    IComparable<T>  interface
                    IComparer<T>  interface


                    VIDQHME RAZLIKAta V KRAQ NA PREDISHTATA LEKCIQ:

                    IComparable<T>  -  Sravnqva s nesho drugo
                    IComparator<T>  -  Sravnqva dve neshta


             */


            /*
                Iterators;
                    IEnumerable<T>  /  IEnumerator<T>
                    Mnogo se polzvat na rabota, foreachvat se.
                    MOje da imame performance penalty ako ne spazvame pravilnoto pisane na kod.                    
                    
                
                    IEnumerable<T>  -  Moje da se iterira s for cikum ili s foreach
                        sudurja samo edin metod GetEnumerator() koito vrushta IEnumerator<T> !!!
                    
                    IEnumerator<T>  -  Tova se vrushta ot GetEnumerator() metoda 
                        MOJEM DA GI ITERIRAME SAMO OT PURVIQ KUM POSLEDNIQ !!!

                        Metoid na IEnumerator<T>:
                            MoveNext() - otivame na sledvashtiq element ot enumeratora
                            Reset() - otivame na purvata poziciq -1  //NE SE POLZVA VECHE MNOGO, MOJE I BEZ NEGO
                            
                        Porperties:
                            Current - vrushta eementa na tekushtata poziciq
                    

                    IEnumerator<T> interface:
                    public interface IEnumerator<T>
                    {
                        bool MoveNext();
                        void Reset();
                        object Current { get; }
                    }


             */

            //Ako izpolzvame foreach nqmame dostu do indexa, za nego ni trqbva for cikul
            // .indexOf() e po bavna operaciq



            //ZADACHA 1
            Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
            Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            Book bookThree = new Book("The Documents in the Case", 1930);

            Library libraryOne = new Library();
            Library libraryTwo = new Library(bookOne, bookTwo, bookThree);


            //ZADACHA 2
            //SEGA MOJEM DA ITERIRAME bibliotekite
            List<Book> books = new List<Book> { bookOne, bookTwo, bookThree };

            var enumerator = libraryTwo.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }

            //FOREACH IZVIKVA .GetEnumerator() I POSLE VSEKI PUT IZVIKVA .MoveNext()
            foreach (var book in libraryTwo)
            {
                //VSEKI PUT SE IZVIKVA .MoveNext() OT LIBRATY ITERATORA
                Console.WriteLine(book.ToString());
            }

            





            //Hubavo e da se znae che Foreach() cikula polzva metodite na IEnumerator<T> interfeisa

            //Dobra praktika e da imame za vseki klas po edin interfeis, purvo se pravqt interfeiite.


            /*
             VAJNOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
             Yeld return ni spestqva implementaciq na IEnumerator<T>
             Vrushta edin element za vsqko prevurtane na cikul.
             
             
             */


            /*
             'params' : Mojem da go slojim v konstruktor ili metod, polzvame go za varirasht broi 
             parametri.
             Moje da podadem primerno mnogo stringove i ako v konstruktura imame       params string[] strArr
             Gi prevrushta na masiv ot stringove.
             
             */

            //Test("Nasko", "Asi", "Toni"); //Mojem da mu podadem kolkoto si iskame stringove.


        }

        public static void Test(params string[] arr) {
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }


    }
}













