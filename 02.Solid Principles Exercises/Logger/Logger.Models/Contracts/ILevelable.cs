namespace Logger.Models.Contracts
{

    public interface ILevelable
    {
        //iznasqme enuma Level v otdelen interfeis zashtoto se polzva ot nqkolko drugi interfeisa
        ErrorLevel Level { get; }
    }
}
