using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {

        SortedSet<Person> sortedSet = new SortedSet<Person>();
        HashSet<Person> hashSet = new HashSet<Person>();


        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var tokens = Console.ReadLine().Split().ToList();
            string name = tokens[0];
            int age = int.Parse(tokens[1]);

            Person person = new Person(name, age);
            sortedSet.Add(person);
            hashSet.Add(person);
        }


        Console.WriteLine(sortedSet.Count);
        Console.WriteLine(hashSet.Count);

    }
}

