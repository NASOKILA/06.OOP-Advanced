using System;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {

        ListIterator listIterator = new ListIterator();
        while (true)
        {
            try
            {
                var tokens = Console.ReadLine().Split().ToArray();
                string command = tokens[0];
                if (command == "END")
                    break;
                
                switch (command)
                {
                    case "Create":
                        if (tokens.Length != 1)
                        {
                            string[] elements = tokens.Skip(1).ToArray();
                            listIterator = new ListIterator(elements);
                        }
                        break;
                    case "HasNext":
                        Console.WriteLine(listIterator.HasNext());
                        break;
                    case "Move":
                        Console.WriteLine(listIterator.Move());
                        break;
                    case "Print":
                        listIterator.Print();
                        break;
                    default:
                        throw new InvalidOperationException("Invalid command!");
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
    }
}