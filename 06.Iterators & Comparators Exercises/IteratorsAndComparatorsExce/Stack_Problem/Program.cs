using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        Stack<string> stackClass = new Stack<string>();

        while (true)
        {

            var tokens = Console.ReadLine()
                .Split(new string[] {" ", ","},StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            try
            {
                switch (tokens[0])
                {
                    case "Push":
                        string[] names = tokens.Skip(1).ToArray();
                        
                        for (int i = 0; i < names.Length; i++)
                            stackClass.Push(names[i]);
                        break;
                    case "Pop":
                        if (stackClass.Count == 0)
                            throw new Exception("No elements");
                        stackClass.Pop();
                        break;
                    case "END":
                        foreach (var item in stackClass)
                        {
                            Console.WriteLine(item);
                        }
                        foreach (var item in stackClass)
                        {
                            Console.WriteLine(item);
                        }

                        Environment.Exit(0);
                        break;

                    default:
                        throw new ArgumentException("Invalid Command !");

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

