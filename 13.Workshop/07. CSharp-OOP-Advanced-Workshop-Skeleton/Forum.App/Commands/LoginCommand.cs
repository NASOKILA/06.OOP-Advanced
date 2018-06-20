namespace Forum.App.Commands
{
    using Contracts;
    using System;
    
    public class LogInCommand : ICommand
    {
        private const string errorMessage = "Username already taken!";

        private IUserService userService;
        private IMenuFactory menuFactory;

        public LogInCommand(IUserService userService, IMenuFactory menuFactory)
        {
            this.userService = userService;
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            //opitvame da registrirame user
            string username = args[0];
            string password = args[1];

            bool validUsername = !string.IsNullOrEmpty(username) && username.Length >= 4;
            bool validPassword = !string.IsNullOrEmpty(password) && password.Length >= 4;


            //validaviq
            if (!validUsername || !validPassword)
            {
                throw new ArgumentException(errorMessage);
            }

            bool userLogIn = this.userService.TryLogInUser(username, password);

            if (!userLogIn)
            {
                throw new System.InvalidOperationException(errorMessage);
            }   

            return this.menuFactory.CreateMenu("MainMenu");
        }
    }
}
