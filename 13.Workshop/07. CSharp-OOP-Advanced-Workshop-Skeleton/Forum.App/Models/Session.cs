namespace Forum.App.Models
{
	using Contracts;
	using DataModels;
    using System.Collections.Generic;
    using System.Linq;

    public class Session : ISession
	{

        private User user;

        //tova ni pokazva kude e bil usera
        public Stack<IMenu> history;

        public Session()
        {
            //setvame si historito
            this.history = new Stack<IMenu>();
        }


        // '?' oznachava ako 'user' e null da ne produljava napraed a da vzeme null
        // vzimame si ot usera Username 
        public string Username => this.user?.Username;

        //na struct ne mojem da slagame null  zatova polzvame '??' 
        //sega ako 'user' e null direktno vzimame nulata
		public int UserId => this.user?.Id ?? 0;

        //kazvame dali usera e lognat, ako 'user' e null znachi ne sme lognati
		public bool IsLoggedIn => this.user != null;

        //vzimame si poslednoto meniu, to segashnoto meniu v nashata logika
        public IMenu CurrentMenu => history.Peek();

        //Tozi metod ni maha poslednoto meniu i ni vrushta predposlednoto
		public IMenu Back()
		{
            if (this.history.Count > 1)
            {
                //mahame poslednoto meniu
                this.history.Pop();
            }

            //vzimame poslednoto meniu koeto predi beshe predposledno
            //i go otvarqme
            this.CurrentMenu.Open();
            
            //I go vrushtame
            return this.CurrentMenu;
		}

        //s tozi metod logvame usera kato go setvame na podadeniq v parametura
		public void LogIn(User user)
		{
            this.user = user;
		}

        //logoutva usera kato go setva na null
		public void LogOut()
		{
            //taka se logoutvame
            this.user = null;
		}

        //dobavqme novo meniu kum istoriqta, ako uspee vrusthame true ako ne false
		public bool PushView(IMenu view)
		{

            //Ne mojem da slojim edno meniu dva puti pored zatova go proverqvame
            //gledame dali i historito e prazno, ako e napravo vkarvame viwto
            if (!this.history.Any() || this.history.Peek() != view)
            {
                this.history.Push(view);
                return true;
            }
            return false;
        }


        //risetevame historito i usera t.e. cqlata sesiq
		public void Reset()
		{
            this.history = new Stack<IMenu>();
            this.user = null;
		}

	}
}
