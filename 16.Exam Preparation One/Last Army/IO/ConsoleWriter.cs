using System;
using System.Text;

public class ConsoleWriter : IConsoleWriter
{
    private StringBuilder stringBuilder;

    public ConsoleWriter()
    {
        this.stringBuilder = new StringBuilder();
    }

    public void AppendLine(string line)
    {
        this.stringBuilder.AppendLine(line);
    }
    
    public void WriteLineAll()
    {
        Console.WriteLine(this.stringBuilder.ToString().Trim());
    }
}





