namespace CommunicationAndEventsExe
{
    using Contracts;
    
    
    public class Dispatcher : INameChangeable
    {

        //implementirame si publichen event na koito shte se zakachat obekti zatova e pubichen za da moje da go namerat
        public event NameChangeEventHandler NameChange;  //eventa ipolzva gorniq delegat
        private string name;

        public Dispatcher(string name)
        {
            this.name = name;
        }
        
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                OnNameChange(new NameChangeEventArgs(value));
                this.name = value;
            }
        }
        
        public void OnNameChange(NameChangeEventArgs args)
        {
            //proverqvam dali eventa e null
            if (this.NameChange != null)
            {
                //Podavame mu sendera koeto sme nie 'this' i poluchenite argumenti
                this.NameChange.Invoke(this, args); // puskame eventa
            }
        }
    }
}
