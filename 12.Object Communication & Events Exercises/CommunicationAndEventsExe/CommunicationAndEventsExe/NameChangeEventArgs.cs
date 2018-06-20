namespace CommunicationAndEventsExe
{
    using System;
    
    //Tozi klas trqbva da podade na vsichki subscriberi na tozi event NA KAKVO SI E SMENIL IMETO TOZI DISPETCHER !!!
    public class NameChangeEventArgs : EventArgs
    {
        public NameChangeEventArgs(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}
