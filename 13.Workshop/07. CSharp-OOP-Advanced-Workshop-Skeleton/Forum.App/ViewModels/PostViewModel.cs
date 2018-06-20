namespace Forum.App.ViewModels
{
    using Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PostViewModel : ContentViewModel, IPostViewModel
    {
        public PostViewModel(string title, string author, string text, IEnumerable<IReplyViewModel> replies) 
            : base(text)
        {
            this.Title = title;
            this.Author = author;
            this.Replies = replies.ToArray(); //kato mu podadem IEnumerable moje damu podadem kakvato  ida e kolekciq
        }

        //tova se pokazva kogato otvorim daden model
        
        public string Title { get; }

        public string Author { get; }

        //public string[] Content => throw new System.NotImplementedException();

        public IReplyViewModel[] Replies { get; }
        
    }
}
