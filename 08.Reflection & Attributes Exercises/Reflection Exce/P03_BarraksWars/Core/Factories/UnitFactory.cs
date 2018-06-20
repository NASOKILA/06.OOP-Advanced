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
            //TODO: implement for Problem 3
            
            //Tova e factory s REFLECTION:


            //Vzimame proekta koito shte se izpulni t.e. tozi proekt
            Assembly assembly = Assembly.GetExecutingAssembly();

            //Vzimame si klasa s ime kato podadenoto 'unitType' ot tozi proekt:
            Type model = assembly.GetTypes().FirstOrDefault(c => c.Name == unitType);

            //ako nqmame takuv tipvrushtame exception
            if (model == null)
                throw new ArgumentException("Invalid Unit Type!");

            //suzdavame si instanciq
            IUnit unit = (IUnit)Activator.CreateInstance(model, false);
            
            return unit;
        }
    }
}
