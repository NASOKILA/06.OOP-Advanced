namespace Forum.App.Commands
{
    using Contracts;
    using System;

    public class CategoriesMenuCommand : NavigationCommand
    {
        public CategoriesMenuCommand(IMenuFactory menuFactory) 
            : base(menuFactory)
        {}
    }
}
