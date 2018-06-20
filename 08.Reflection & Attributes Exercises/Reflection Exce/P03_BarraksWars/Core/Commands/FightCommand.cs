namespace P03_BarraksWars.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using _03BarracksFactory.Contracts;

    public class FightCommand : Command
    {
        public FightCommand(string[] data) 
            : base(data)
        {}

        public override string Execute()
        {
            Environment.Exit(0);
            return "";
        }
    }
}
