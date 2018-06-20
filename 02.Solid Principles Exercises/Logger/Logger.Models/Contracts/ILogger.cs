
namespace Logger.Models.Contracts
{
    using System.Collections.Generic;

    public interface ILogger
    {
        //pravim si i getter za appenderi za da mojem da gi dostupvame  
        IReadOnlyCollection<IAppender> Appenders { get; }
        void Log(IError error);
    }
}