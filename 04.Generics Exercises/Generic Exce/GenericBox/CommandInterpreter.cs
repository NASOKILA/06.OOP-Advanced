using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class CommandInterpreter
{

    public void Run(CustomList<string> list)
    {
        

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] tokens = input
                 .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                 .ToArray();

            string command = tokens[0];

            switch (command)
            {
                case "Add":
                    string value = tokens[1];
                    list.Add(value);
                    break;
                case "Remove":
                    int index = int.Parse(tokens[1]);
                    list.Remove(index);
                    break;
                case "Contains":
                    string containsValue = tokens[1];
                    Console.WriteLine(list.Contains(containsValue));
                    break;
                case "Swap":
                    int indexOne = int.Parse(tokens[1]);
                    int indexTwo = int.Parse(tokens[2]);
                    list.Swap(indexOne, indexTwo);
                    break;
                case "Greater":
                    string greaterValue = tokens[1];
                    Console.WriteLine(list.CountGreaterThan(greaterValue));
                    break;
                case "Max":
                    Console.WriteLine(list.Max());
                    break;
                case "Min":
                    Console.WriteLine(list.Min());
                    break;
                case "Sort":
                    Sorter.Sort(list);
                    break;
                case "Print":
                    list.Print();
                    break;
                default:
                    throw new InvalidOperationException("Non existing command!");
            }

        }
    }

}

