using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {

        List<Person> people = new List<Person>();
        
        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            var tokens = command.Split().ToList();
            string name = tokens[0];
            int age = int.Parse(tokens[1]);
            string town = tokens[2];

            Person person = new Person(name, age, town);
            people.Add(person);
        }

        int n = int.Parse(Console.ReadLine());

        Person currentPErson = people[n - 1];

        int equalPeople = 0;
        int deferentPeople = 0;

        foreach (Person p in people)
        {
            int match = currentPErson.CompareTo(p);
            if (match == 0)
            {
                equalPeople++;
            }
            else
            {
                deferentPeople++;
            }

        }


        if (equalPeople == 1)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine($"{equalPeople} {deferentPeople} {people.Count}");
        }

    }
}

