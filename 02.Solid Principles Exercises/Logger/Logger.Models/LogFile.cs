
namespace Logger.Models
{
    using System;
    using Contracts;
    using System.IO;

    public class LogFile : ILogFile
    {
        const string DefaultPath = "./data/";

        public LogFile(string fileName)
        {
            this.Path = DefaultPath + fileName;
            InitializeFile();
            this.Size = 0;
        }

        private void InitializeFile()
        {
            Directory.CreateDirectory(DefaultPath);
            System.IO.File.AppendAllText(this.Path, ""); 
        }

        public int Size { get; private set; }

        public string Path { get; }

        public void WriteToFile(string errorLog)
        {
            System.IO.File.AppendAllText(this.Path, errorLog + Environment.NewLine);

            int addedSize = 0;

            for (int i = 0; i < errorLog.Length; i++)
                addedSize += errorLog[i];
           
            this.Size += addedSize;
        }
    }
}