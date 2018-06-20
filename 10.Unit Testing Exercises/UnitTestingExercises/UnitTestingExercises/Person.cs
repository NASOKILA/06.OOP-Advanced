using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    private int id;

    private string username;


    public Person(int id, string username)
    {
        this.Id = id;
        this.Username = username;
    }
    
    public int Id
    {
        get { return id; }
        private set { id = value; }
    }

    public string Username
    {
        get { return username; }
        private set { username = value; }
    }
    


}

