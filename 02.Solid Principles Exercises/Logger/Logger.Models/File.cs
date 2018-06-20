namespace Logger.Models
{

    using Contracts;
    using System;

    public class File : ILogFile
    {
        public int Size => throw new NotImplementedException();

        public string Path => throw new NotImplementedException();

        public void Append(string errorText)
        {
            throw new NotImplementedException();
        }

        public void WriteToFile(string errorText)
        {
            throw new NotImplementedException();
        }
    }
}
