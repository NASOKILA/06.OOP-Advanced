namespace CommunicationAndEventsExe.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    //suzdavame si delegata poluchava sender i argumenti
    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);

    public interface INameChangeable : INamable
    {
      //publichen event na koito shte se zakachat obekti zatova e pubichen za da moje da go namerat
        event NameChangeEventHandler NameChange;
        void OnNameChange(NameChangeEventArgs args);
    }
}
