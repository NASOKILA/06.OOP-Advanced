using System;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        int[] stones = Console.ReadLine()
            .Split(", ")
            .Select(int.Parse)
            .ToArray();

        Lake lake = new Lake(stones);

        Console.WriteLine(string.Join(", ", lake));
    }
}