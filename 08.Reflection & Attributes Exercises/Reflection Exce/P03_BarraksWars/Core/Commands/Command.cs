namespace P03_BarraksWars.Core.Commands
{
    using _03BarracksFactory.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Command : IExecutable
    {

        private string[] data;

        protected Command(string[] data)
        {
            this.Data = data;
        }

        protected string[] Data
        {
            get { return data; }
            set { data = value; }
        }
        
        //Implementirame metoda ot interfeisa abstraktno !!!
        public abstract string Execute();
    }
}
