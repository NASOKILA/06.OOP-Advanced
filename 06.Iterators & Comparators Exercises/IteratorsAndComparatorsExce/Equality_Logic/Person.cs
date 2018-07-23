using System;

public class Person : IComparable<Person>
{
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    private string name;
    private int age;

    public override bool Equals(object obj)
    {
        if (obj is Person objPerson)
        {
            return this.name.Equals(objPerson.name) && this.age.Equals(objPerson.age);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return this.name.GetHashCode() + this.age.GetHashCode();
    }
    
    public int CompareTo(Person other)
    {
        int result = this.name.CompareTo(other.name);

        if (result == 0)
        {
            return this.age.CompareTo(other.age); 
        }

        return result;
    }
}