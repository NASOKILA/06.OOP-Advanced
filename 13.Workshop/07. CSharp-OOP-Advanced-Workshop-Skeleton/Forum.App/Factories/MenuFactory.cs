namespace Forum.App.Factories
{
    using Forum.App.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class MenuFactory : IMenuFactory
    {

        //injectvame service providera
        private IServiceProvider serviceProvider;

        public MenuFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }


        public IMenu CreateMenu(string menuName)
        {
            Type menuType = Assembly.GetExecutingAssembly()
                    .GetTypes().FirstOrDefault(t => t.Name == menuName);

            //proverqvame dali go ima
            if (menuType == null)
            {
                throw new ArgumentException($"{menuName} not found!");
            }


            //proverqvame dali tova e meniu
            if (!typeof(IMenu).IsAssignableFrom(menuType))
            {
                throw new ArgumentException($"{menuName} is not an IMenu!");
            }
            
            //vzimame parametrite ot purviq konstruktor
            ParameterInfo[] ctorParams = menuType
                .GetConstructors()
                .First()
                .GetParameters();

            //pravim si obekt koito shte polzvame za da si napravim 'Menu'
            object[] arguments = new object[ctorParams.Length];


            for (int i = 0; i < arguments.Length; i++)
            {
                //iskame ot servisa tochniq tip na parametrite
                arguments[i] = serviceProvider.GetService(ctorParams[i].ParameterType);
            }
  
            //pravim si Meniuto
            IMenu menu = (IMenu)Activator.CreateInstance(menuType, arguments);

            //oi go vrushtame
            return menu;
        }


    }
}
