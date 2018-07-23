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

        foreach (var methodInfo in type.GetMembers(BindingFlags.Static
            | BindingFlags.Instance
            | BindingFlags.Public))
        {
            if (methodInfo.CustomAttributes
                .Any(n => n.AttributeType == typeof(SoftUniAttribute)))
            {
                var attrs = methodInfo.GetCustomAttributes(false);

                foreach (SoftUniAttribute attr in attrs)
                {
                    Console.WriteLine($"{methodInfo.Name} is written by {attr.Name}");
                }
            }
        }     
    }
}