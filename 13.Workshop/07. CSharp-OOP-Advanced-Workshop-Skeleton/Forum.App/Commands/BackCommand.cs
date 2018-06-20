namespace Forum.App.Commands
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BackCommand : ICommand
    {

        //na back komandta i trqbva sessiq zashtoto tam se sudurjat meniutata prez koito sme minali 

        private ISession session;

        public BackCommand(ISession session)
        {
            this.session = session; 
        }

        public IMenu Execute(params string[] args)
        {
            //vrushtame se nazad kato cuknem back butona
            //vika back metoda na sessiqta  
            return this.session.Back();
        }
    }
}
