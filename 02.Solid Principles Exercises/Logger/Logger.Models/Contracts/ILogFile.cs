namespace Logger.Models.Contracts
{
    public interface ILogFile
    {
        void WriteToFile(string errorLog);

        int Size { get; }

        string Path { get; }
    }
}
