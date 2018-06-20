namespace Forum.App.ViewModels
{
    using Contracts;
    
    public class PostInfoViewModel : IPostInfoViewModel
    {
        //durjim info za posta i negovite replies


        public PostInfoViewModel(int id, string title, int replyCount)
        {
            this.Id = id;
            this.Title = title;
            this.ReplyCount = ReplyCount;
        }


        public int Id { get; }

        public string Title { get; }

        public int ReplyCount { get; }
    }
}
