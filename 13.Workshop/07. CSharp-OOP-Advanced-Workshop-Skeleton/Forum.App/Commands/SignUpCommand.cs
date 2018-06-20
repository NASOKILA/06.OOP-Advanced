namespace Forum.App.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;

    public class SignUpCommand : ICommand
    {
        private IUserService userService;
        private IMenuFactory menuFactory;

        public SignUpCommand(IUserService userService, IMenuFactory menuFactory)
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
                throw new ArgumentException($"Invalid Username or Password !");
            }

            bool userSignedUp = this.userService.TrySignUpUser(username, password);

            if (!userSignedUp)
            {
                throw new System.InvalidOperationException("Username already taken!");
            }

            return this.menuFactory.CreateMenu("MainMenu");
        }
    }


}
