using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        //ZADACHA 0:
        /* 
        var box = new Box<int>(123123);
        Console.WriteLine(box);

        var box2 = new Box<string>("life in a box");
        Console.WriteLine(box2);
        */


        //ZADACHA 1 i ZADACHA 2
        /*
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            //ZADACHA 1:
            string command = Console.ReadLine();
            var stringBox = new Box<string>(command);
            Console.WriteLine(stringBox.ToString());
            
            //ZADACHA 2:
            int command = int.Parse(Console.ReadLine());
            var stringBox = new Box<int>(command);
            Console.WriteLine(stringBox.ToString());
        }
        */


        //ZADACHA 3
        /*
        var list = new List<string>();
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
            list.Add(Console.ReadLine());
        

        int[] indexes = Console.ReadLine()
            .Split(new string[] { " " },StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

        Swap(list, indexes[0], indexes[1]);

        for (int i = 0; i < n; i++) {
            var stringBox = new Box<string>(list[i]);
            Console.WriteLine(stringBox.ToString());
        }
        */


        //ZADACHA 4
        /*
        var list = new List<int>();
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
            list.Add(int.Parse(Console.ReadLine()));


        int[] indexes = Console.ReadLine()
            .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

        Swap(list, indexes[0], indexes[1]);

        for (int i = 0; i < n; i++)
        {
            var stringBox = new Box<int>(list[i]);
            Console.WriteLine(stringBox.ToString());
        }
        */

        //ZADACHA 5
        /*
        var list = new List<Box<string>>();
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string command = Console.ReadLine();
            var stringBox = new Box<string>(command);
            list.Add(stringBox);
        }

        var comparableBox = new Box<string>(Console.ReadLine());

        int count = Box<string>.Compare(list, comparableBox);
        Console.WriteLine(count);
        */


        //ZADACHA 6
        /*
        var list = new List<Box<double>>();
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            double command = double.Parse(Console.ReadLine());
            var stringBox = new Box<double>(command);
            list.Add(stringBox);
        }

        var comparableBox = new Box<double>(double.Parse(Console.ReadLine()));

        int count = Box<double>.Compare(list, comparableBox);
        Console.WriteLine(count);
        */



        //ZADACHA 7
         
        CustomList<string> customList = new CustomList<string>();
        CommandInterpreter cm = new CommandInterpreter();
        cm.Run(customList);
        

        //ZADACHA 8
        /*
        CustomList<string> customList = new CustomList<string>();
        CommandInterpreter cm = new CommandInterpreter();
        cm.Run(customList);
        */





        //ZADACHA 9
        /*
        CustomList<string> customList = new CustomList<string>();
        CommandInterpreter cm = new CommandInterpreter();
        cm.Run(customList);
        */





        //ZADACHA 10
        /*
        string[] lineOne = Console.ReadLine()
            .Split()
            .ToArray();

        string name = lineOne[0] + ' ' + lineOne[1];
        string address = lineOne[2];

        Tuple<string, string> tupleOne = new Tuple<string, string>(name, address);
        Console.WriteLine(tupleOne.Print());


        string[] lineTwo = Console.ReadLine()
            .Split()
            .ToArray();

        string nameTwo = lineTwo[0];
        int beers = int.Parse(lineTwo[1]);

        Tuple<string, int> tupleTwo = new Tuple<string, int>(nameTwo, beers);
        Console.WriteLine(tupleTwo.Print());


        string[] lineThree = Console.ReadLine()
            .Split()
            .ToArray();

        int age = int.Parse(lineThree[0]);
        double price = double.Parse(lineThree[1]);

        Tuple<int, double> tupleThree = new Tuple<int, double>(age, price);
        Console.WriteLine(tupleThree.Print());
        */






        //ZADACHA 11
        /*
        string[] lineOne = Console.ReadLine()
           .Split()
           .ToArray();

        string name = lineOne[0] + ' ' + lineOne[1];
        string address = lineOne[2];
        string town = lineOne[3];

        Threeuple<string, string, string> threeupleOne = new Threeuple<string, string, string>(name, address, town);
        Console.WriteLine(threeupleOne.Print());



        string[] lineTwo = Console.ReadLine()
           .Split()
           .ToArray();

        string nameTwo = lineTwo[0];
        int beers = int.Parse(lineTwo[1]);
        bool drunk = lineTwo[2] == "drunk" ? true : false;

        Threeuple<string, int, bool> threeupleTwo = new Threeuple<string, int, bool>(nameTwo, beers, drunk);
        Console.WriteLine(threeupleTwo.Print());
        

        string[] lineThree = Console.ReadLine()
           .Split()
           .ToArray();

        string myName = lineThree[0];
        double balance = double.Parse(lineThree[1]);
        string bankName = lineThree[2];

        Threeuple<string, double, string> threeupleThree = new Threeuple<string, double, string>(myName, balance, bankName);
        Console.WriteLine(threeupleThree.Print());
        */






    }

    public static void Swap<T>(List<T> list, int indexOne, int indexTwo)
    {
        var temp = list[indexOne];
        list[indexOne] = list[indexTwo];
        list[indexTwo] = temp;
    }
    
}





