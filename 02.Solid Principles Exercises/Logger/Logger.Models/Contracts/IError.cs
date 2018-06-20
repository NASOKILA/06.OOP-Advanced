namespace Logger.Models.Contracts
{
    using System;

    public interface IError : ILevelable
    {
        //pishem samo getteri zashtoto ne iskame da imame publichnis setteri    

        //veche go ima tozi enum ErrorLevel Level; zashtoto go nasledqva ot ILevalable
        //ErrorLevel Level { get; }

        DateTime DateTime { get; }

        string Message { get; }

    }
}

