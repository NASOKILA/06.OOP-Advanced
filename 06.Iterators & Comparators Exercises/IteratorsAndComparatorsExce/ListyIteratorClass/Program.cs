using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        ListyIterator<string> listyIterator = new ListyIterator<string>(new List<string>());

        while (true)
        {

            var tokens = Console.ReadLine().Split().ToList();

            try
            {
                switch (tokens[0])
                {
                    case "Create":
                        List<string> names = new List<string>();

                        for (int i = 1; i < tokens.Count; i++)
                            names.Add(tokens[i]);

                        listyIterator = new ListyIterator<string>(names);
                        break;
                    case "Move":

                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "HasNext":

                        Console.WriteLine(listyIterator.HasNext());
                        break;
                    case "Print":
                        listyIterator.Print();
                        break;
                    case "PrintAll":
                        listyIterator.PrintAll();
                        break;
                    case "END":
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

