using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        NameComparator nameComparator = new NameComparator();
        AgeComparator ageComparator = new AgeComparator();

        //podavame nameComparatora vutre za da se sortira
        SortedSet<Person> peopleOrderedByName = new SortedSet<Person>(nameComparator);

        //podavame ageComparatora vutre za da se sortira
        SortedSet<Person> peopleOrderedByAge = new SortedSet<Person>(ageComparator);

        
        for (int i = 0; i < n; i++)
        {
            var tokens = Console.ReadLine().Split().ToList();
            string name = tokens[0];
            int age = int.Parse(tokens[1]);
            
            Person person = new Person(name, age);
            peopleOrderedByName.Add(person);
            peopleOrderedByAge.Add(person);
        }

        foreach (var item in peopleOrderedByName)
        {
            Console.WriteLine(item.name + ' ' + item.age);
        }

        foreach (var item in peopleOrderedByAge)
        {
            Console.WriteLine(item.name + ' ' + item.age);
        }

    }
}

