 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;
    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            //TODO put your reflection code here
            Type type = Type.GetType("P01_HarvestingFields.HarvestingFields");

            var allFields = type.GetFields(
                BindingFlags.Public
                | BindingFlags.NonPublic
                | BindingFlags.Static
                | BindingFlags.Instance);

            var privateFields = type.GetFields(
                BindingFlags.NonPublic
                | BindingFlags.Static
                | BindingFlags.Instance);

            var protectedFields = type.GetFields(
                BindingFlags.NonPublic
                | BindingFlags.Public
                | BindingFlags.Instance);

            var publicFields = type.GetFields(
                BindingFlags.Public
                | BindingFlags.Static
                | BindingFlags.Instance);


            string command = "";
            while ((command = Console.ReadLine()) != "HARVEST")
            {
                switch (command)
                {
                    case "private":
                        foreach (var field in privateFields.Where(f => !f.IsFamily))
                            Console.WriteLine($"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");
                        break;

                    case "protected":
                        foreach (var field in protectedFields.Where(f => f.IsFamily))
                            Console.WriteLine($"protected {field.FieldType.Name} {field.Name}");
                        break;

                    case "public":
                        foreach (var field in publicFields)
                            Console.WriteLine($"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");
                        break;

                    case "all":
                        foreach (FieldInfo field in allFields)
                        {
                            string accesModifier = "";

                            if (field.IsFamily)
                                accesModifier = "protected";
                            else if (!field.IsFamily && field.IsPrivate)
                                accesModifier = "private";
                            else if (field.IsPublic)
                                accesModifier = "public";
                            
                            Console.WriteLine($"{accesModifier} {field.FieldType.Name} {field.Name}");
                        }
                        break;

                    default:
                        throw new InvalidOperationException("Invalid input !");
                }
            }
            


        }
    }
}
