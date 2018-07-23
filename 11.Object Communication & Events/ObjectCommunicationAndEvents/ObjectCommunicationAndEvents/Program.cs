using System;


public class Program
{
    public delegate void DelegateToPrint(string stringToPrint);
	
    static void Main(string[] args)
    {

        Console.WriteLine(DateTime.Now.Second);
        
        System.Threading.Thread.Sleep(2000);

        Console.WriteLine(DateTime.Now.Second);

        Console.WriteLine();

        Program.PrintToConsole("Hello World!");

        DelegateToPrint functionToPrint = PrintToConsole;
		
        functionToPrint("Hello World From a delegate function!");

        Action<string> actionPrint = PrintToConsole1;

        DelegateToPrint functonDoNothing = DoNothing;
        functonDoNothing("Nothing");
        
        Program.PrintStringByFunction(functionToPrint, "Hello from delegate passed as a parameter");

        Console.WriteLine();
        
		DelegateToPrint delegateToPrint1 = PrintToConsole1;
        delegateToPrint1("Hello");

        DelegateToPrint delegateToPrint2 = PrintToConsole2;
        delegateToPrint2("Hello");

        Console.WriteLine();
        DelegateToPrint delegateToPrintChain = PrintToConsole1;
        delegateToPrintChain += PrintToConsole2;
        delegateToPrintChain += PrintToConsole3;
        delegateToPrintChain("Hello");

        delegateToPrintChain += PrintToConsole2;
        delegateToPrintChain -= PrintToConsole2;

        Console.WriteLine();
        var functionsUsedByDelegate = delegateToPrintChain.GetInvocationList(); 

        foreach (var del in functionsUsedByDelegate)
        {
            Console.WriteLine(del);
        }

        Console.WriteLine();
       
	    delegateToPrint1.Invoke("Invoke method used");
        
        delegateToPrint1?.Invoke("Not null");
    }

    private static void PrintToConsole(string stringToPrint)
    {
        Console.WriteLine(stringToPrint);
    }

    private static void PrintToConsole1(string stringToPrint)
    {
        Console.WriteLine("!: 1 " + stringToPrint);
    }
    
    private static void PrintToConsole2(string stringToPrint)
    {
        Console.WriteLine("!: 2 " + stringToPrint);
    }

    private static void PrintToConsole3(string stringToPrint)
    {
        Console.WriteLine("!: 3 " + stringToPrint);
    }

    private static void DoNothing(string stringParam)
    {}

    private static void PrintStringByFunction(DelegateToPrint delegateToPrint, string str)
    {
        delegateToPrint(str);
    }
}