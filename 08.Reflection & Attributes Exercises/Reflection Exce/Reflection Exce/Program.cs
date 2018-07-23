using System;


public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(true ^ true);
        Console.WriteLine(false ^ false);
        Console.WriteLine(true ^ false);
        Console.WriteLine(false ^ true);
        Console.WriteLine(1 ^ 0);
    }
}