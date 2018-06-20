namespace P03_BarraksWars.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using _03BarracksFactory.Contracts;

    
    public class AddCommand : Command
    {
        [Inject]
        private IRepository repository;

        [Inject]
        private IUnitFactory unitFactory;

        public AddCommand(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data)
        {
            this.Repository = repository;
            this.UnitFactory = unitFactory;
        }



        protected IRepository Repository
        {
            get { return repository; }
            set { repository = value; }
        }

        protected IUnitFactory UnitFactory
        {
            get { return unitFactory; }
            set { unitFactory = value; }
        }


        public override string Execute()
        {
            var commandType = Data[1];
            IUnit unitToAdd = UnitFactory.CreateUnit(commandType);
            this.Repository.AddUnit(unitToAdd);
            string output = commandType + " added!";
            return output;
        }
    }
}
