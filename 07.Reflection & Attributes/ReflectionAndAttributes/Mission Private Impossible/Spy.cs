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

            foreach (FieldInfo field in fields.Where(f => namesOfFieldsToInvestigate.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        var sb = new StringBuilder();

        Type classType = Type.GetType(className);

        if (classType == null)
            return sb.ToString().Trim();

        FieldInfo[] publicFields = classType.GetFields(
            BindingFlags.Instance |
            BindingFlags.Static | 
            BindingFlags.Public);

        foreach (FieldInfo field in publicFields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        MethodInfo[] publicMethods = classType.GetMethods(BindingFlags.Instance
            | BindingFlags.Public 
            | BindingFlags.NonPublic
            | BindingFlags.Static);
        
        foreach (MethodInfo method in publicMethods)
        {
            if (method.Name.StartsWith("get") && method.IsPrivate)
                sb.AppendLine($"{method.Name} have to be public!");
        
            if (method.Name.StartsWith("set") && method.IsPublic)
                sb.AppendLine($"{method.Name} have to be private!");
        }
        
        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {

        StringBuilder sb = new StringBuilder();
        Type type = Type.GetType(className);

        MethodInfo[] privateMethods = type.GetMethods(BindingFlags.NonPublic 
            | BindingFlags.Instance);

        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {type.BaseType.Name}");

        foreach (var method in privateMethods)
        {
            sb.AppendLine(method.Name);
        }

        return sb.ToString().Trim();
    }
}