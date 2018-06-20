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

    //KOI IZVIKVA TOZI METOD
    //SRAVNQVAME IMETO I VUZRASTTA NA PODADENIQ OBEKT S TEZI NA NASHIQ
    public override bool Equals(object obj)
    {
        //VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!
        //AKO SLED Person mu slojim promenliva direktno ni q kastva kum Person
        if (obj is Person objPerson)
        {
            return this.name.Equals(objPerson.name) && this.age.Equals(objPerson.age);
        }

        return false;
    }

    
    //HashSet-a tursi tazi funkciq zashtoto sravnqva po HashCode !!!!!!!!!!!!!!!!!!!!!!!!!
    public override int GetHashCode()
    {
        //subirame hesh kodovete na imeto i na vuzrastta na tekushtiq Person
        return this.name.GetHashCode() + this.age.GetHashCode();
    }
    

    //SortedSet-a NI TURSI NQKAKVO SRAVNENIQ PO KOETO DA SORTIRA PO DEFAULT, ZA TOVA NI TURSI IComparable<Person>
    public int CompareTo(Person other)
    {
        //sravnqvame purvo po ime i posle po vuzrast
        int result = this.name.CompareTo(other.name);

        if (result == 0)
        {
            return this.age.CompareTo(other.age); 
        }

        return result;
    }
}