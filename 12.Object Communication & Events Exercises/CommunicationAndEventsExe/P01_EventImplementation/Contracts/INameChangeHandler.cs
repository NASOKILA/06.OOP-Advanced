namespace CommunicationAndEventsExe.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface INameChangeHandler
    {
        void OnDispatcherNameChange(object sender, NameChangeEventArgs args);
    }
}
