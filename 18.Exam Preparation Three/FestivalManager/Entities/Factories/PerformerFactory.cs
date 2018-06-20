namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class PerformerFactory : IPerformerFactory
	{
		public IPerformer CreatePerformer(string name, int age)
		{

            Type @class = Assembly.GetCallingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name == "Performer");

            IPerformer performer = (IPerformer)Activator.CreateInstance(@class, name, age);

            return performer;
		}
	}
}