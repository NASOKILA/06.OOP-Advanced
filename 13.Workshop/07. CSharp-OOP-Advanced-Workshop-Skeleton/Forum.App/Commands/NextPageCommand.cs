namespace Forum.App.Commands
{
    using Contracts;

    public class NextPageCommand : ICommand
    {
        private ISession session;


        public NextPageCommand(ISession session)
        {
            this.session = session;
        }

        public IMenu Execute(params string[] args)
        {

            IMenu currentMenu = this.session.CurrentMenu;

            //proverqvame dali tiout mu e IPaginatedenu da go kastne v pomenlivata paginatedMenu
            if (currentMenu is IPaginatedMenu paginatedMenu)
            {
                paginatedMenu.ChangePage();  //vurvim edna stranica nazad
            }

            return currentMenu;
        }
    }
}
