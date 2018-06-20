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
            foreach (FieldInfo field in fields.Where( f => namesOfFieldsToInvestigate.Contains(f.Name)))
            {
                //05.Za da vzemem stoinostta ni trqbva instanciqta, ZA TOVA Q SUZDAVAME ZA DA ZNAEM OT KOQ INStaNCIQ VZIMAME STOINOSTI
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
            
        }

        return sb.ToString().Trim(); 

    }

}


