using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


public class Tracker
{
    public static void PrintMethodsByAuthor()
    {
        Type type = typeof(StartUp);

        //Vzimame publichnite metodi na tozi StartUp klasa
        foreach (var methodInfo in type.GetMembers(BindingFlags.Static
            | BindingFlags.Instance
            | BindingFlags.Public))
        {

            if (methodInfo.CustomAttributes
                .Any(n => n.AttributeType == typeof(SoftUniAttribute)))
            {

                //zarejdame vsichki atributi na tozi metod
                var attrs = methodInfo.GetCustomAttributes(false);

                foreach (SoftUniAttribute attr in attrs)
                {
                    //printirame imato na metoda i koi go e napisal
                    Console.WriteLine($"{methodInfo.Name} is written by {attr.Name}");
                }
            }

        }
        
    }

}

