namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;
    using _03BarracksFactory.Models.Units;
    using System.Reflection;
    using System.Linq;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        { 
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type model = assembly.GetTypes().FirstOrDefault(c => c.Name == unitType);

            if (model == null)
                throw new ArgumentException("Invalid Unit Type!");
			
            IUnit unit = (IUnit)Activator.CreateInstance(model, false);
            
            return unit;
        }
    }
}