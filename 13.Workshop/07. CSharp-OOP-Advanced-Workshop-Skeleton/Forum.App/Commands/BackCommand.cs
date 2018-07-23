namespace Forum.App.Commands
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BackCommand : ICommand
    {
        private ISession session;

        public BackCommand(ISession session)
        {
            this.session = session; 
        }

        public IMenu Execute(params string[] args)
        {    
            return this.session.Back();
        }
    }
}