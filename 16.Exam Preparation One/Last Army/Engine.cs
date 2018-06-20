using System;
using System.Text;

public class Engine
{

    private const string poolbackCommand = "Enough! Pull back!";

    //polzvame si reader i writer chrez klasovete ConsoleReader() i ConsoleWriter()
    private IConsoleReader reader;
    private IConsoleWriter writer;

    public Engine()
    {
        this.reader = new ConsoleReader();
        this.writer = new ConsoleWriter();
    }


    public void Run()
    {

        string input = reader.ReadLine();
        GameController gameController = new GameController(writer);
        


        while (!input.Equals(poolbackCommand))
        {
            try
            {
                gameController.GiveInputToGameController(input);
            }
            catch (ArgumentException arg)
            {
                writer.AppendLine(arg.Message);
            }

            input = this.reader.ReadLine();
        }

        gameController.RequestResult();
        
        this.writer.WriteLineAll();
    }


}

