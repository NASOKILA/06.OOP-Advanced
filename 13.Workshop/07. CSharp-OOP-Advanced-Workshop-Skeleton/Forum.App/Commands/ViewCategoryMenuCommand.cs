namespace Forum.App.Commands
{
    using Contracts;
    using System.Collections.Generic;
    using System.Text;

    public class ViewCategoryMenuCommand : ICommand
    {

        //postservice otgovarq za postovete i tehnite kategorii
        private IPostService postService;
        private IMenuFactory menuFactory;


        public ViewCategoryMenuCommand(IMenuFactory menuFactory, IPostService postService)
        {
            this.postService = postService;
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            int categoryId = int.Parse(args[0]);

            IEnumerable<IPostInfoViewModel> posts = this.postService
                .GetCategoryPostsInfo(categoryId);

            string commandName = this.GetType().Name;
            
            string menuName = commandName.Substring(0, commandName.Length -
                "Command".Length);

            IIdHoldingMenu menu = (IIdHoldingMenu)this.menuFactory.CreateMenu(menuName);

            menu.SetId(categoryId);

            return menu;
        }
    }
}
