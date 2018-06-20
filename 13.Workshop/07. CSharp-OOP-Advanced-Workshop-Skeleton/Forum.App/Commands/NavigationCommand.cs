namespace Forum.App.Commands
{
    using Forum.App.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class NavigationCommand : ICommand
    {

        //trqbva ni menuFactory koeto idva ot serviceProvidera
        private IMenuFactory menuFactory;

        protected NavigationCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            //mahame 'Command' ot imeto

            string commandName = this.GetType().Name;
            string menuName = commandName.Substring(0, commandName.Length - "Command".Length);

            IMenu menu = this.menuFactory.CreateMenu(menuName);

            return menu;
        }

    }
}
