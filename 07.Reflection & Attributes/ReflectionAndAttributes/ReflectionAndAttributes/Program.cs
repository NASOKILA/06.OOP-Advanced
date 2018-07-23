using ReflectionDemo;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

public class Program
{
    static void Main(string[] args)
    {
        
         Comments:
            Reflection & Attributs:
                judge e naprave s reflektion, avtomatiziran e da ni proverqva celiq kod.

        Kakvo sa atribbutite ?
            Koga da polzvame reflection ?  -  polzva se kogato se nalaga.

                
            Za reflektion nqma public, private, tam vsichko se vijda, mnogo e moshten,
            moje na momenti da e noj s dve ustrieta.

            kakvo sa atributite ?
            shte si naravin nash si atribut,
            predimno se polzvat build in attributi na rabota

        Shte razgledame :
            01.Kakvo koga i kak se polzva.
            02.Reflection API:
                Type clas,
                Reflecting fields,
                Reflection constructors,
                Reflecting Methods
            03.Attributes:
                Prilagane na atribute na kodovi elementi,
                Build-in attributes,
                Defining attributes.


        //VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //METADANNI:
                Tova sa danni za nashite metodi.
                Osven ime, parametri i return type chres ATTRIBUTI mojem da mu dobavim 
                oshte dopulnitelna informaciq
         
        //Metaprogramirane:
            Edni programi polzvat drugi programi kato tehni danni.
            Mojem da deklarirame nashite klasove i metodi sus metadanni.
            Te stavat danni za drugi programi.
            Meta Programite mogat da budat napraveni taka che da mogat da se:
                Chetat,
                Generirat,
                Analizirat,
                Transformirat,
                I promenqt sebesi DOKATO SE IZPILNAVAT.




        01.Reflection KAK? KOGA? ZASHTO?:
            Polzva se ot programisti koito pravat Frameworci primerno, zashtoto te izsledvat kod,
            izsledvat metadannite na klasovete za da si napravqt tehnite klasove.
            Polzva se mnogo ot VisualStudio ot Unit testovete.
            EDIN KOD ANALIZIRA DRUG KOD.
            Mojem da SUZDAVAEMA PROGRAMI S KOITO DA generirame avtomatichno drugi 
                klasove i programi RUNTIME (pri izpulnenie).
                No tova trudno se poddurja.
            
            S REFLECTiON PROGRAMITE MOGAT DA ANALIZIRAT I POPRAVQT SEBESI.

            Koga da polzvame reflection ?
                Unit testovete polzvat reflektion.
                Polzva me go kogato ni se nalaga.
                
                Ako trqbva da sravnim dva obekta ot tip 'Person' obache po adres i adresa Ne e
                prosto string a obekt ot tip 'Address' sus negovi si poleta i stoinosti,
                za da sravnim dvate Person obeta trqbva da polzame Reflection NO IMA I DRUGI
                NACHINI.

                Mojem da polzvame metod koito da ni izledva koda na primerno 500 choveka dali v daden klas imat
                primerno pravilno napisan konstruktor, tova e Unit test i se pravi s Reflection.
                
                NQMAME SECURITY RESTRICTIONS:
                    Mojem primerno da polzvame obekti v nevaliden state, da izvikvame metodi v
                    greshna posledovatelnost BEZ PROBLEM.
            

          02.Reflection API:
                Osnova na Reflection API e klasa 'Type'.
                 
                Vsichko ima 'GetType()', mojem da mu vzemem tipa na klasa i da go izsledvame:
                    Type type = typeof(className);

                 OBACHE IMA I DRUGI NACHINI IMENNO PO IMETO NA NAMESPACE-a:
                    Type myType = Type.GetType("Namespace.ClassName");


         */
        Console.WriteLine("TYPE: --------------------------------------------------------");

        Type type = typeof(ReflectionDemo.TestReflection);
        Console.WriteLine(type);

        Console.WriteLine(type.FullName); 
        Console.WriteLine(type.Name);
        Console.WriteLine(type.Module); 
        Console.WriteLine(type.BaseType); 

        Console.WriteLine();
        Console.WriteLine("TYPE: --------------------------------------------------------");

        Type myType = Type.GetType("ReflectionDemo.TestReflection");
        Console.WriteLine(type.FullName); 
        Console.WriteLine(type.Name);
        Console.WriteLine(type.Module); 
        Console.WriteLine(type.BaseType); 

        Console.WriteLine();
		
        var interfaces = type.GetInterfaces();

        foreach (var interf in interfaces)
        {
            Console.WriteLine(interf);
        }

        Console.WriteLine();
        Console.WriteLine("CONSTRUCTORS: --------------------------------------------------------");
        
        var constructors = type.GetConstructors();

        foreach (var ctor in constructors)
        {
            Console.WriteLine(ctor); 
        }

        Console.WriteLine();
        Console.WriteLine("INSTANCE: --------------------------------------------------------");

        var instanceNoParams = Activator.CreateInstance(typeof(ReflectionDemo.TestReflection));

        var instanceIntParam = Activator.CreateInstance(typeof(ReflectionDemo.TestReflection),
            new object[] { 10 });

        var instanceDoubleParam = Activator.CreateInstance(typeof(ReflectionDemo.TestReflection),
            new object[] { 10.3 });

        var instanceStringParam = Activator.CreateInstance(typeof(ReflectionDemo.TestReflection),
            new object[] { "Say Hello" });
        
        var sb = Activator.CreateInstance(Type.GetType("System.Text.StringBuilder"));

        ((System.Text.StringBuilder)sb).AppendLine("hahhaTest");
        Console.WriteLine(sb);

        Console.WriteLine();
        Console.WriteLine("POLETA: --------------------------------------------------------");

        Type type2 = typeof(ReflectionDemo.TestReflection);
        var fields = type2.GetFields();

        foreach (var field in fields)
        {
            Console.WriteLine(field);
        }

        Console.WriteLine();
        Console.WriteLine("STATIC POLETA: --------------------------------------------------------");
      
        var staticFields = type2.GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
        foreach (var field in staticFields)
        {
            Console.WriteLine(field);
        }

        Console.WriteLine();
        Console.WriteLine("INSTANCE POLETA: --------------------------------------------------------");

        var instanceFields = type2.GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var field in instanceFields)
        {
            Console.WriteLine(field);
        }

        Console.WriteLine();
        Console.WriteLine("PRIVATE POLETA: --------------------------------------------------------");

        var privateFields = type2.GetFields(System.Reflection.BindingFlags.Instance |
            System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

        foreach (var field in privateFields)
        {
            Console.WriteLine(field);
        }

        Console.WriteLine();
        Console.WriteLine(".GetField(FIELDNAME): --------------------------------------------------------");

        FieldInfo singlePublicField = type2.GetField("publicInstance");
        Console.WriteLine(singlePublicField.Name); 
        Console.WriteLine(singlePublicField.FieldType);

        FieldInfo singlePublicStaticField = type2.GetField("publicStatic");
        Console.WriteLine(singlePublicStaticField);

        Console.WriteLine();
        Console.WriteLine("Methods: --------------------------------------------------------");

        var methods = type2.GetMethods();
        foreach (var meth in methods)
        {
            Console.WriteLine(meth);
        }

        Console.WriteLine();
        Console.WriteLine("PROVERQVANE NA POLETA: --------------------------------------------------------");
        Console.WriteLine("IsPrivate - Dali e private, IsPublic - Dali e Public, IsNonPublic - Dali NE e public, IsFamily - Dali e Protected, IsAssembly - Dali e Hidden");
        Console.WriteLine();

        Console.WriteLine("Invoking Contructors: ----------------------------------------------");
        
        Type currentType = typeof(StringBuilder);
        
        var intConstructor = currentType.GetConstructor(new Type[] { typeof(int), typeof(int) });

        var sb2 = intConstructor.Invoke(new object[] {5, 100});
        
        Console.WriteLine();
        Console.WriteLine("Invoking Methods: ----------------------------------------------");

        var appendMethod = currentType.GetMethod("Append", new Type[] { typeof(string) });
        appendMethod.Invoke(sb2, new object[] { "append called" }); 

        Console.WriteLine(sb2); 

        Console.WriteLine(); Console.WriteLine();
		
        TestReflection tr = new TestReflection();
      
        var trTest = (TestReflection) Activator.CreateInstance(typeof(TestReflection));
        
        Console.WriteLine();
        Console.WriteLine($"Backing Fields:");
        Console.WriteLine($"Kogato imame samo property BEZ pole v daden klas, to kompiltora ni go suzdava avtomatichno !!!");
    }

    class Student
    {
        public Student()
        {}

        public string Name { get; set; }

        [DataMember(Name = "student_age")] /
        public int Age { get; set; }
        
        public string SayHello()
        {
            return $"Hello,my name is {this.Name} an I am {this.Age} years old.";
        }
    }
}