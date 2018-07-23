namespace Forum.App.Services
{
    using Contracts;
    using ViewModels;
    using Forum.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Forum.DataModels;

    public class PostService : IPostService
    {
        private ForumData forumdata;
		
        private IUserService userService;
        
        public PostService(ForumData forumdata, IUserService userService)
        {
            this.forumdata = forumdata;
            this.userService = userService;
        }
        
        public int AddPost(int authorId, string postTitle, string postCategory, string postContent)
        {
            User author = this.forumdata.Users.Find(u => u.Id == authorId);

            if (author == null)
            {
                throw new ArgumentException($"User with id {authorId} not found!");
            }

            int postId = this.forumdata.Posts.LastOrDefault()?.Id + 1 ?? 1;

            Category category = this.EnsureCategory(postCategory);

            Post post = new Post(postId, postTitle, postContent, category.Id, authorId, new List<int>());

            this.forumdata.Posts.Add(post);
            author.Posts.Add(postId);
            category.Posts.Add(postId);

            forumdata.SaveChanges();

            return postId;
        }

        private Category EnsureCategory(string postCategory)
        {
            Category category = this.forumdata.Categories.FirstOrDefault(c => c.Name == postCategory);

            if (category == null)
            {
                int categoryId = this.forumdata.Categories.LastOrDefault()?.Id + 1 ?? 1;
                category = new Category(categoryId, postCategory, new List<int>());
                this.forumdata.Categories.Add(category);
            }

            return category;
        }

        public void AddReplyToPost(int postId, string replyContents, int userId)
        {
            Post post = this.forumdata.Posts.Find(p => p.Id == postId);
            User author = this.userService.GetUserById(userId);

            int replyId = this.forumdata.Replies.LastOrDefault()?.Id + 1 ?? 1;
            Reply reply = new Reply(replyId, replyContents, userId, postId);

            this.forumdata.Replies.Add(reply);
            post.Replies.Add(replyId);
            this.forumdata.SaveChanges();
        }

        public IEnumerable<ICategoryInfoViewModel> GetAllCategories()
        {
            IEnumerable<ICategoryInfoViewModel> categories = this.forumdata
                .Categories
                .Select(c => new CategoryInfoViewModel(c.Id, c.Name, c.Posts.Count));

            return categories;
        }

        public string GetCategoryName(int categoryId)
        {
            string categoryName =  this.forumdata.Categories
                   .FirstOrDefault(c => c.Id == categoryId).Name;

            if (categoryName == null)
            {
                throw new ArgumentException($"Category with ID {categoryId} not found!");
            }

            return categoryName;
        }

        public IEnumerable<IPostInfoViewModel> GetCategoryPostsInfo(int categoryId)
        {
            IEnumerable<IPostInfoViewModel> posts =
                this.forumdata.Posts.Where(p => p.CategoryId == categoryId)
                .Select(p => new PostInfoViewModel(p.Id, p.Title, p.Replies.Count));

            return posts;
        }

        public IPostViewModel GetPostViewModel(int postId)
        {
            Post post = this.forumdata.Posts.FirstOrDefault(p => p.Id == postId);

            if (post == null)
            {
                throw new ArgumentException($"Pos with ID {postId} not found!");
            }

            string author = this.userService.GetUserName(post.AuthorId);

            IPostViewModel postViewModel =
                new PostViewModel(post.Title, author, post.Content, this.getPostReplies(postId));
            
            return postViewModel;
        }

        private IEnumerable<IReplyViewModel> getPostReplies(int postId)
        {
            IEnumerable <IReplyViewModel>  replies = this.forumdata.Replies.Where(r => r.PostId == postId)
                .Select(r =>  new ReplyViewModel(this.userService.GetUserName(r.AuthorId), r.Content));

            return replies;
        }
    }
}
