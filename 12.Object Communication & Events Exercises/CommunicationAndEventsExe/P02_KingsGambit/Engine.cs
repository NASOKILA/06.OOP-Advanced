namespace P02_KingsGambit
{
    using Interfaces;
    using System;
    using System.Linq;

    public class Engine : IEngine
    {
        private IKing king;

        public Engine(IKing king)
        {
            this.king = king;
        }

        public void Run()
        {
            string input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split().ToArray();

                string command = tokens[0];
                string name = tokens[1];

                switch (command)
                {
                    case "Attack":
                        king.GetAttacked();
                        break;
                    case "Kill":
                        ISubordinate subordinate = king.Subordinates.First(s => s.Name == name);

                        subordinate.TakeDamage();

                        break;
                    default:
                        throw new ArgumentException("Invalid Command !");
                }
            }
        }
    }
}