using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {     
        CustomList<string> customList = new CustomList<string>();
        CommandInterpreter cm = new CommandInterpreter();
        cm.Run(customList);  
    }

    public static void Swap<T>(List<T> list, int indexOne, int indexTwo)
    {
        var temp = list[indexOne];
        list[indexOne] = list[indexTwo];
        list[indexTwo] = temp;
    }
}