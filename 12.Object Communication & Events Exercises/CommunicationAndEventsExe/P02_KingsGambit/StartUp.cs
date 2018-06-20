namespace P02_KingsGambit
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            //vzimame si kralq ot tozi metod zaedno sus RoyalGuards i Foormans 
            IKing king = SetUpKing();

            IEngine engine = new Engine(king);
            engine.Run();

        }

        private static IKing SetUpKing()
        {

            //Pravim si purvo kralq
            string name = Console.ReadLine();
            List<ISubordinate> subordinates = new List<ISubordinate>();
            IKing king = new King(name, subordinates);

            //posle RoyalGuards
            string[] royalGuards = Console.ReadLine().Split().ToArray();

            //dobavqme gi v KRALQ
            foreach (string rgName in royalGuards)
                king.AddSubortinate(new RoyalGuard(rgName));


            //Sushtoto pravim i za Footman-ite
            string[] footmans = Console.ReadLine().Split().ToArray();

            //dobavqme gi v KRALQ
            foreach (string fmName in footmans)
                king.AddSubortinate(new Footman(fmName));

            //vtushtame kralq
            return king;
        }

    }
}
