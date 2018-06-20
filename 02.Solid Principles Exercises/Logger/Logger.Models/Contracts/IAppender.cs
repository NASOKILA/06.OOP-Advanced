namespace Logger.Models.Contracts
{

    public interface IAppender : ILevelable
    {
        //layouta formatira greshki
        ILayout Layout { get; }

        //veche go ima tozi enum ErrorLevel Level; zashtoto go nasledqva ot ILevalable
        //ErrorLevel Level { get; }


        //podavame mu greshka za da moje da q formatira chrez layouta
        void Append(IError error);
    }
}