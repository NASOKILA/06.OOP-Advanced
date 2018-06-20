namespace Logger.Models.Contracts
{
    public interface ILayout
    {
        //layouta ni dava formata za opisvane na nashata greshka
        //metod koito vzima greshka i vrushta string
        string FormatError(IError error);
    }
}