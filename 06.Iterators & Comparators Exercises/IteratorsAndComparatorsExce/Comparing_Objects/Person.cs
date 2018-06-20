using System;
using System.Collections.Generic;
using System.Text;

public class Person : IComparable<Person>
{

    public Person(string name, int age, string town)
    {
        this.name = name;
        this.age = age;
        this.town = town;
    }

    private int age { get; set; }

    private string name { get; set; }

    private string town { get; set; }

    public int CompareTo(Person other)
    {

        int nameComparison = this.name.CompareTo(other.name);

        if (nameComparison == 0)
        {
            int ageComparison = this.age.CompareTo(other.age);

            if (ageComparison == 0)
            {
                int townComparison = this.town.CompareTo(other.town);
                return townComparison;
            }

            return ageComparison;
        }
         
        return nameComparison;
   
    }
}

