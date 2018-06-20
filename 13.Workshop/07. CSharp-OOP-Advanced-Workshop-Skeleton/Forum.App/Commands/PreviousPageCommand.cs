namespace Forum.App.Commands
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PreviousPageCommand : ICommand
    {

        private ISession session;
        
        public PreviousPageCommand(ISession session)
        {
            this.session = session;
        }

        public IMenu Execute(params string[] args)
        {
            IMenu currentMenu = this.session.CurrentMenu;

            //proverqvame dali tiout mu e IPaginatedenu da go kastne v pomenlivata paginatedMenu
            if (currentMenu is IPaginatedMenu paginatedMenu)
            {
                paginatedMenu.ChangePage(false);  //vurvim edna stranica nazad
            }

            return currentMenu;
        }
    }
}
