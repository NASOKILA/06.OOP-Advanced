using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    //slagame mu 'params' zashtoto ne znaem kolko stringove shte ni se podadat
    public string StealFieldInfo(string nameOfClassToInvestigate, params string[] namesOfFieldsToInvestigate)
    {
        var sb = new StringBuilder();

        //01 Vzimame si tipa na klasa
        Type @class = Type.GetType(nameOfClassToInvestigate);//nameOfClassToInvestigate

        if (@class != null)
        {
            sb.AppendLine($"Class under investigation: {nameOfClassToInvestigate}");

            //02.vzimame si vsichki poleta statichni, instantni, publichni i new publihni 
            FieldInfo[] fields = @class.GetFields(BindingFlags.Static
                | BindingFlags.Instance
                | BindingFlags.Public
                | BindingFlags.NonPublic);

            //03.suzdavame si instanciq bez parametri ZA DAMOJEM DA VZIMAME StoiNOSti OT NEQ
            Object classInstance = Activator.CreateInstance(@class, new object[] { });

            //04.Iterirame samo tezi poleta koito se sudurjat v namesOfFieldsToInvestigate zashtoto tezi trqbva da tursim
            foreach (FieldInfo field in fields.Where(f => namesOfFieldsToInvestigate.Contains(f.Name)))
            {
                //05.Za da vzemem stoinostta ni trqbva instanciqta, ZA TOVA Q SUZDAVAME ZA DA ZNAEM OT KOQ INStaNCIQ VZIMAME STOINOSTI
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

        }

        return sb.ToString().Trim();

    }

    public string AnalyzeAcessModifiers(string className)
    {
        var sb = new StringBuilder();

        //01. Vzimam si tipa
        Type classType = Type.GetType(className);

        if (classType == null)
            return sb.ToString().Trim();

        //02.Vzimame si vsichki PUBLICHNI poleta 
        FieldInfo[] publicFields = classType.GetFields(
            BindingFlags.Instance |
            BindingFlags.Static | 
            BindingFlags.Public);

        foreach (FieldInfo field in publicFields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }


        //03. Vzimam vsichki metodi
        MethodInfo[] publicMethods = classType.GetMethods(BindingFlags.Instance
            | BindingFlags.Public 
            | BindingFlags.NonPublic
            | BindingFlags.Static);
        
        foreach (MethodInfo method in publicMethods)
        {
            //ako imeto zapochva s 'get' znachi e getter
            if (method.Name.StartsWith("get") && method.IsPrivate)
                sb.AppendLine($"{method.Name} have to be public!");
        
            //ako zapochva sus set znachi e setter
            if (method.Name.StartsWith("set") && method.IsPublic)
                sb.AppendLine($"{method.Name} have to be private!");
        }
        


        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {

        StringBuilder sb = new StringBuilder();
        Type type = Type.GetType(className);

        //Ne vzimame statichnite metodi
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


