namespace Forum.App.Commands
{
    using Forum.App.Contracts;

    public class LogInMenuCommand : NavigationCommand
    {
        public LogInMenuCommand(IMenuFactory menuFactory) 
            : base(menuFactory)
        {}

    }
}
