namespace Forum.App.Commands
{
    using Contracts;
    using System.Collections.Generic;
    using System.Text;
    using Forum.App.Contracts;

    public class SignUpMenuCommand : NavigationCommand
    {
        public SignUpMenuCommand(IMenuFactory menuFactory) 
            : base(menuFactory)
        {
        }
    }
}
