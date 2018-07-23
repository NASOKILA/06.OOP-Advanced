namespace CommunicationAndEventsExe
{
    using Contracts;
    
    
    public class Dispatcher : INameChangeable
    {
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
            if (this.NameChange != null)
            {
                this.NameChange.Invoke(this, args); 
            }
        }
    }
}