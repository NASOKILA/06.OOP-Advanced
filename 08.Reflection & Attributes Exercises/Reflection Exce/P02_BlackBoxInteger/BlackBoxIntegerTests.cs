namespace P02_BlackBoxInteger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type type = typeof(BlackBoxInteger);
            
            //ZA DA IZPOLZVAME 'PRIVATE' KONSTRUKTURA TRQBVA DA MU SLOJIM NAKRAQ 'true' KOETO OZNACHAVA:
                                                        //NonPuplic = true;
            var instance = Activator.CreateInstance(type, true);

            //vzimame si private Field-a
            FieldInfo innerValueField = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)[0];

            var Add = type.GetMethod("Add", BindingFlags.NonPublic | BindingFlags.Instance);
            var Subtract = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)[1];
            var Multiply = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)[2];
            var Divide = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)[3];
            var LeftShift = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)[4];
            var RightShift = type.GetMethod("RightShift", BindingFlags.NonPublic | BindingFlags.Instance);
            var Finalize = type.GetMethod("Finalize", BindingFlags.NonPublic | BindingFlags.Instance);

            while (true)
            {
                var tokens = Console.ReadLine().Split("_").ToList();

                string command = tokens[0];

                if (command == "END")
                    break;

                int number = int.Parse(tokens[1]);

                switch (command)
                {
                    case "Add": //PODAVAME MU INSTANCIQTA ZA DA ZNAE KUDE DA IZOULNI METODA !!!!!!!!!
                        Add.Invoke(instance, new object[] { number });
                        Console.WriteLine(innerValueField.GetValue(instance)); //printirame tipa na innerValue ot tazi instanciq
                        break;
                    case "Subtract":
                        Subtract.Invoke(instance, new object[] { number });
                        Console.WriteLine(innerValueField.GetValue(instance));
                        break;
                    case "Multiply":
                        Multiply.Invoke(instance, new object[] { number });
                        Console.WriteLine(innerValueField.GetValue(instance));
                        break;
                    case "Divide":
                        Divide.Invoke(instance, new object[] { number });
                        Console.WriteLine(innerValueField.GetValue(instance));
                        break;
                    case "LeftShift":
                        LeftShift.Invoke(instance, new object[] { number });
                        Console.WriteLine(innerValueField.GetValue(instance));
                        break;
                    case "RightShift":
                        RightShift.Invoke(instance, new object[] { number });
                        Console.WriteLine(innerValueField.GetValue(instance));
                        break;
                }
            }
            
        }
    }
}
