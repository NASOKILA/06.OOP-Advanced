using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class ExtendDatabase
{

    private Person[] storage = new Person[16];

    public ExtendDatabase(params Person[] people)
    {
        if (people.Length > 16)
            throw new InvalidOperationException("Size bigger than 16!");

        for (int i = 0; i < people.Length; i++)
            storage[i] = people[i];
    }
    
    public void Add(Person person)
    {
        bool personUsernameExists = this.storage.Any(p => p != null && p.Username == person.Username);

        bool personIdExists = this.storage.Any(p => p != null && p.Id == person.Id);


        if (personUsernameExists)
            throw new InvalidOperationException("Username already exists!");
        
        if (personIdExists)
            throw new InvalidOperationException("Id already exists!");


        bool personAdded = false;

        for (int i = 0; i < this.storage.Length; i++)
        {
            if (storage[i] == null)
            {
                storage[i] = person;
                personAdded = true;
                break;
            }
        }

        if (!personAdded)
            throw new InvalidOperationException("Storage is full!");

    }

    public void Remove()
    {
        bool personRemoved = false;

        for (int i = this.storage.Length - 1; i >= 0; i--)
        {
            if (this.storage[i] != null)
            {
                this.storage[i] = null;
                personRemoved = true;
                break;
            }
        }
        if (!personRemoved)
            throw new InvalidOperationException("Storage is Empty!");
    }

    public Person[] Fetch()
    {
        int count = this.storage.Where(l => l != null).Count();
        Person[] resultArray = new Person[count];

        for (int i = 0; i < this.storage.Length; i++)
        {
            if (this.storage[i] != null)
                resultArray[i] = this.storage[i];
        }

        return resultArray;
    }
    
    public Person FindByUsername(string username)
    {

        if (username == null)
            throw new ArgumentNullException();
        
        Person person = this.storage.FirstOrDefault(p => p != null && p.Username == username);

        if (person == null)
            throw new InvalidOperationException($"User with Username {username} don't exists!");

        return person;
    }

    public Person FindById(int id)
    {

        if (id < 0)
            throw new ArgumentOutOfRangeException();

        Person person = this.storage.FirstOrDefault(p => p != null && p.Id == id);

        if (person == null)
            throw new InvalidOperationException($"User with Id {id} don't exists!");
        
        return person;
    }


}

