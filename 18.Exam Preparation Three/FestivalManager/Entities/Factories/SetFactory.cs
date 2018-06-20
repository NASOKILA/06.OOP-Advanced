using System;

using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;


namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;
	using Sets;

	public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
           
            Type @class = Assembly.GetCallingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name == type);

            ISet set = Activator.CreateInstance(@class, name) as ISet;

            return set;
        }
	}




}
