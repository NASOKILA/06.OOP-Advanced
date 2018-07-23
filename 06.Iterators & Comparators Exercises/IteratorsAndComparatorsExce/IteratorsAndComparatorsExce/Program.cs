using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        LinkedList<string> linked = new LinkedList<string>();
        
        linked.AddLast("cat");
        linked.AddLast("dog");
        linked.AddLast("man");
        linked.AddFirst("first");
       
        foreach (var item in linked)
        {
            Console.WriteLine(item);
        }
    }
}