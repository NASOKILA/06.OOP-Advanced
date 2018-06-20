using System;
using System.Collections.Generic;

namespace Generic_Exce
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Comments:
                Generic tipovete se polzvat poveche kogato iskame da si pravim 
                primerno nqkakva biblioteka.

                V praktikata mnogo puti shte izpolzvme Generic metodi za da ne prepisvame kod
                v sluchi che imame sushtiq metod koito da raboti s drug tip.
                No e hubavo da gi znaem.

            
            
                Faktoritata gi polzvame za da ne pishem mnogo dumichkata 'new', po sigurno e.
                V .NET CORE mnogo ot operaciita sa MNOGO PO BURZI otkolkoto v .NET Framework.

                ICompare<> e razlichno ot IComparable<>

             */


            Person p1 = new Person("Nasko", 25);
            Person p2 = new Person("Asi", 26);

            int older = p1.CompareTo(p2);
            Console.WriteLine(older); // -1 znachi p1 ne e po star ot p2


            //shte polzvame sega komparatorite:

            PersonAgeComparator ageComparator = new PersonAgeComparator();
            int compareAges = ageComparator.Compare(p1, p2);
            Console.WriteLine(compareAges);


            PersonNameComparator nameComparator = new PersonNameComparator();
            int compareNames = nameComparator.Compare(p1, p2);
            Console.WriteLine(compareNames); 


            //PO TOQ NACHIM MOJEM DA SORTIRAME

        }

        //IComparable<T>
        public class Person : IComparable<Person> //Iska da implementirame metod CompareTo()
        {
            
            public Person(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }

            public string Name { get; set; }

            public int Age { get; set; }

            public int CompareTo(Person other)
            {
                //Tuk mojem da sravnqvame nashiq person sus drug person podaden v metoda
                return this.Age.CompareTo(other.Age); //sravnqvame gi po vuzrastta im.
            }
        }


        //IComparer<T>
        //Kazvame kakvo iskame da sravnqvame v tozi klas
        public class PersonAgeComparator : IComparer<Person> //avtomatichno ni suzdava metod Compare sled implementaciq
        {
            //v sluchaq sme kazli che shte sravnqvaem hora
            public int Compare(Person x, Person y)
            {
                //Shte gi sravnqvame po vuzrastta im
                return x.Age.CompareTo(y.Age);
            }
        }

        //I edin komparator koito sravnqva po imena
        public class PersonNameComparator : IComparer<Person> //avtomatichno ni suzdava metod Compare sled implementaciq
        {
            public int Compare(Person x, Person y)
            {
                //Shte gi sravnqvame po imenata im
                return x.Name.CompareTo(y.Name);
            }
        }

    }
}
