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
            IKing king = SetUpKing();

            IEngine engine = new Engine(king);
            engine.Run();
        }

        private static IKing SetUpKing()
        {
            string name = Console.ReadLine();
            List<ISubordinate> subordinates = new List<ISubordinate>();
            IKing king = new King(name, subordinates);

            string[] royalGuards = Console.ReadLine().Split().ToArray();

            foreach (string rgName in royalGuards)
                king.AddSubortinate(new RoyalGuard(rgName));

            string[] footmans = Console.ReadLine().Split().ToArray();

            foreach (string fmName in footmans)
                king.AddSubortinate(new Footman(fmName));

            return king;
        }
    }
}