using System;
using System.Collections.Generic;

namespace Generic_Exce
{
    class Program
    {
        static void Main(string[] args)
        {   
            Person p1 = new Person("Nasko", 25);
            Person p2 = new Person("Asi", 26);

            int older = p1.CompareTo(p2);
            Console.WriteLine(older); 

            PersonAgeComparator ageComparator = new PersonAgeComparator();
            int compareAges = ageComparator.Compare(p1, p2);
            Console.WriteLine(compareAges);

            PersonNameComparator nameComparator = new PersonNameComparator();
            int compareNames = nameComparator.Compare(p1, p2);
            Console.WriteLine(compareNames); 
        }

        public class Person : IComparable<Person> 
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
                return this.Age.CompareTo(other.Age); 
            }
        }

        public class PersonAgeComparator : IComparer<Person> 
        {
            public int Compare(Person x, Person y)
            {
                return x.Age.CompareTo(y.Age);
            }
        }

        public class PersonNameComparator : IComparer<Person> 
        {
            public int Compare(Person x, Person y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }
    }
}