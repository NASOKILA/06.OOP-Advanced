using System;
using System.Collections.Generic;
using System.Text;


public class Person
{

    private string name;
    private int age;

    public string Name
    {
        get { return this.name; }
    }

    public int Age
    {
        get { return this.age; }
    }

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
    
}

