namespace P03_BarraksWars.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using _03BarracksFactory.Contracts;

    public class RetireCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RetireCommand(string[] data, IRepository repository) 
            : base(data)
        {
            this.Repository = repository;
        }

        protected IRepository Repository
        {
            get { return repository; }
            set { repository = value; }
        }

        public override string Execute()
        {
            string unitType = Data[1];

            try
            {
                this.Repository.RemoveUnit(unitType);
                return $"{unitType} retired!";
            }
            catch (Exception e)
            {
                //podavame nov exception sus stariq v nego
                throw new ArgumentException("No such units in repository.", e);
            }
        
        }
    }
}
