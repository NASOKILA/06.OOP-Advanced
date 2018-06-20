namespace Forum.App.Commands
{
    using Contracts;
    

    public class WriteCommand : ICommand
    {

        private ISession session;

        public WriteCommand(ISession session)
        {
            this.session = session;
        }

        public IMenu Execute(params string[] args)
        {
            IMenu curentMenu = this.session.CurrentMenu;

            //proverqvame dali ne e ITExtAreaMenu
            if (curentMenu is ITextAreaMenu textAreaMenu)
            {
                textAreaMenu.TextArea.Write();
            }

            return curentMenu;
        }
    }
}
