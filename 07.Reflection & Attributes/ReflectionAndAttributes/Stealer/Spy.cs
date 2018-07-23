using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string nameOfClassToInvestigate, params string[] namesOfFieldsToInvestigate)
    {
        var sb = new StringBuilder();

        Type @class = Type.GetType(nameOfClassToInvestigate);

        if (@class != null)
        {
            sb.AppendLine($"Class under investigation: {nameOfClassToInvestigate}");
             
            FieldInfo[] fields = @class.GetFields(BindingFlags.Static
                | BindingFlags.Instance
                | BindingFlags.Public
                | BindingFlags.NonPublic);

            Object classInstance = Activator.CreateInstance(@class, new object[] { });

            foreach (FieldInfo field in fields.Where( f => namesOfFieldsToInvestigate.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }          
        }

        return sb.ToString().Trim(); 
    }
}