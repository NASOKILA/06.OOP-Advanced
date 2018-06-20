namespace Forum.App.Commands
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LogOutMenuCommand : ICommand
    {

        private ISession session;
        private IMenuFactory menuFactory;

        public LogOutMenuCommand(ISession session, IMenuFactory menuFactory)
        {
            this.session = session;
            this.menuFactory = menuFactory;
        }

        //resetvame sessiqta kato cuknem na logout
        public IMenu Execute(params string[] args)
        {
            this.session.Reset();
            return this.menuFactory.CreateMenu("MainMenu");
        }
    }
}
