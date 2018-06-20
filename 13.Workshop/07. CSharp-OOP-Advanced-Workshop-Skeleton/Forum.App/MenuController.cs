namespace Forum.App
{
	using System;
	using Microsoft.Extensions.DependencyInjection;
	using Contracts;
	using Menus;

	internal class MenuController : IMainController
	{
        
        //Tova e nashiq osnoven kontroller
        //podavame mu vsichko do sega


        private IServiceProvider serviceProvider;
		private IForumViewEngine viewEngine;
		private ISession session;
		private ICommandFactory commandFactory;

		public MenuController(ICommandFactory commandFactory, 
            ISession session, 
            IServiceProvider serviceProvider, 
            IForumViewEngine viewEngine)
		{
			this.viewEngine = viewEngine;
            this.serviceProvider = serviceProvider;
            this.session = session;
            this.commandFactory = commandFactory;

            //inicializirame sessiqta
            this.InitializeSession();
		}

		private string Username { get; set; }
        
        //sega current menu idva ot sessiqta     
		private IMenu CurrentMenu => this.session.CurrentMenu;

		
		private void InitializeSession()
		{
			this.session.PushView(new MainMenu(this.session,
				this.serviceProvider.GetService<ILabelFactory>(),
				this.serviceProvider.GetService<ICommandFactory>()));

			this.RenderCurrentView();
		}

		private void RenderCurrentView()
		{
			this.viewEngine.RenderMenu(this.CurrentMenu);
		}

		public void MarkOption()
		{
			this.viewEngine.Mark(this.CurrentMenu.CurrentOption);
		}

		public void UnmarkOption()
		{
			this.viewEngine.Mark(this.CurrentMenu.CurrentOption, false);
		}

		public void NextOption()
		{
			this.CurrentMenu.NextOption();
		}

		public void PreviousOption()
		{
			this.CurrentMenu.PreviousOption();
		}

		public void Back()
		{
			this.session.Back();
			RenderCurrentView();
		}

		public void Execute()
		{
			this.session.PushView(this.CurrentMenu.ExecuteCommand());
			this.RenderCurrentView();
		}
	}
}