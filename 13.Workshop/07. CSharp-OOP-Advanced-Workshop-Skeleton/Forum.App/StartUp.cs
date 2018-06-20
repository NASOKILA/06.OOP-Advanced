namespace Forum.App
{
	using System;

    //toq paket ni trqbva zaduljitelno ZA DA POLZVAME '            IServiceCollection service = new ServiceCollection();'
    using Microsoft.Extensions.DependencyInjection;

	using Contracts;
	using Factories;
    using Forum.Data;
    using Services;
    using Models;

    public class StartUp
	{
        
		public static void Main(string[] args)
		{
            //vzimame si providera ot funkciqta koqto napravihme
            IServiceProvider serviceProvider = ConfigureServices();

            IMainController menu = serviceProvider.GetService<IMainController>();
                
			Engine engine = new Engine(menu);
			engine.Run();
		}
         

        //za dependency injection config, kazvame koi klas za koi interfeis otgovarq
        //mojem da imame mnogo klasove koito da implementirat edin u susht interfeis i service providera 
        //trqbva da znae koi klas koga da vurne
        private static IServiceProvider ConfigureServices()
		{

            //Trqbva ni da instalirame  -  Microsoft.Extension.Dependency.Injection

            //using Microsoft.Extensions.DependencyInjection;

            //pravim si service kolekciqta
            IServiceCollection services = new ServiceCollection();

            /*
                DOBAVQME SI SERVIITE KOITO SHTE NI TRQBVAT
                AddTransient()  -  suzdava vremenni obekti koito sled upotreba izchezvat
                AddSingleton()  -  podobno e na gornoto samoche ne e statichno i nikoga nqma 
                    da imame dva edini i sushti obekti
             */
             
            //PURVO FAKTORITATA
            //kogato poiskame ICommandFactory da ni dava CommandFactory SAMOCHE SAMO EDIN PUT DA GO NAPRAVI
            services.AddSingleton<ICommandFactory, CommandFactory>();
            services.AddSingleton<ILabelFactory, LabelFactory>();
            services.AddSingleton<IMenuFactory, MenuFactory>();
            services.AddSingleton<ITextAreaFactory, TextAreaFactory>();
            

            //FORUM DATA
            services.AddSingleton<ForumData>(); // nqma interfeis

            //SERVISITE
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IForumReader, ForumConsoleReader>();

            //SESSION,  MENU CONTROLLER, ForumViewEngine
            services.AddSingleton<ISession, Session>();
            services.AddSingleton<IMainController, MenuController>();
            services.AddSingleton<IForumViewEngine, ForumViewEngine>();
             
            
            //i posle si vzimame servie providera
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            //vrushtae providera
            return serviceProvider;
        }
	}
}
