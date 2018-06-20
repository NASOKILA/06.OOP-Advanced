namespace Forum.App.Services
{
    using System;
    using Contracts;
    using Forum.DataModels;
    using Forum.Data;
    using Forum.App.Models;
    using System.Linq;

    public class UserService : IUserService
    {
        //vzimame si forum datata
        private ForumData forumData;

        // i sessiq
        private ISession session;

        //setvame gi ot konstruktura
        public UserService(ForumData forumData, ISession session)
        {
            this.forumData = forumData;
            this.session = session;
        }

        //kato implementirame interfeisa pouchavame metodi koito za sega nqma da polzvame

        public User GetUserById(int userId)
        {
            User user = this.forumData.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentException($"User with ID {userId} not found!");
            }

            return user;
        }

        public string GetUserName(int userId)
        {
            //polzvame gorniq metod aza da ne prepisvame kod
            User user = this.GetUserById(userId);

            return user.Username;
        }

        public bool TryLogInUser(string username, string password)
        {
            //proverqvame dali imame user s takava parola i iusername
            User user = this.forumData
                .Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user == null)
            {
                return false;
            }

            //risetvame sessiqta
            this.session.Reset();

            //za da logne musera trqbva da go zapishem v sessiqta
            this.session.LogIn(user);

            return true; 
        }

        public bool TrySignUpUser(string username, string password)
        {
            //proverqvame dali veche imme takuv user
            bool userAlreadyExists = this.forumData.Users.Any(u => u.Username == username);

            if (userAlreadyExists)
            {
                return false;
            }

            //ako nqma takuv user go suzdavame 

            int userId = this.forumData.Users.LastOrDefault()?.Id + 1 ?? 1;

            User user = new User(userId, username, password);

            this.forumData.Users.Add(user);

            //ako reshim da si promenim username trqbva da go zapishem vuv frameworka zatova vinagi se kazva save changes
            this.forumData.SaveChanges();

            //ako vsichko e ok se logvame
            this.TryLogInUser(username, password);

            return true;
        }

    }

}





