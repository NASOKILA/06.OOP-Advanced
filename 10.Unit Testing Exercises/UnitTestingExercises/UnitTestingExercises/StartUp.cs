using System;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {

        /*
        int[] arr = new int[2] { 1, 2};
        Database db = new Database(arr);

        db.Add(6);
        db.Add(7);

        int[] elements = db.Fetch();

        Console.WriteLine(string.Join(", ", elements));
        



        Person[] arr = new Person[2] { new Person(1, "Ivcho_55"), new Person(2, "Nasko_123") };
        ExtendDatabase db = new ExtendDatabase(arr);




        db.Add(new Person(3, "Anton_48"));
        db.Add(new Person(4, "Anton_47"));
        db.Remove();

        Person p = db.FindByUsername(null);
        Console.WriteLine(p.Id + " " + p.Username);

        Person[] elements = db.Fetch();

        foreach (var item in elements)
            Console.WriteLine(item.Id + " " + item.Username);
        


        Console.WriteLine(Math.Floor(0.0));
        Console.WriteLine(Math.Floor(-0.0));

        Console.WriteLine(Math.Floor(0.0123));
        Console.WriteLine(Math.Floor(-0.0123));
        */


        /*
        ListIterator listIterator2 = new ListIterator();

        listIterator2.Print();

        ListIterator listIterator = new ListIterator(new string[] { "nasko", "asi" });


        Console.WriteLine(listIterator.Move());
        Console.WriteLine(listIterator.Move());
        Console.WriteLine(listIterator.Move());

        listIterator.Print();
        */


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





