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
        /*
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
        Console.WriteLine(type); //TestReflection

        //KLASA Type E MNOGO BOGAT IMA MNOGO RABOTI            PROBVAI:  type. + SPACE
        Console.WriteLine(type.FullName); //ako ima namespace shte da go izpishe.
        Console.WriteLine(type.Name);
        Console.WriteLine(type.Module); // dll
        Console.WriteLine(type.BaseType); //pokazva che bazoviq klas ni e 'object'


        //PO DRUGIQ NACHIN POKAZVA SUSHTOTO NESHTO
        Console.WriteLine();
        Console.WriteLine("TYPE: --------------------------------------------------------");

        Type myType = Type.GetType("ReflectionDemo.TestReflection");
        Console.WriteLine(type.FullName); //ako ima namespace shte da go izpishe.
        Console.WriteLine(type.Name);
        Console.WriteLine(type.Module); // dll
        Console.WriteLine(type.BaseType); //pokazva che bazoviq klas ni e 'object'


        Console.WriteLine();
        //Type extendva mnogo interfeisi.
        //imame metod    .GetInterfaces();
        var interfaces = type.GetInterfaces();

        foreach (var interf in interfaces)
        {
            Console.WriteLine(interf);
        }

        //Dori i da nasledqva edin interfeis koito da nasledqva drug, pak ni vadi dvata interfeisa.
        //Vrishta vsicki navurzan interfeisi




        Console.WriteLine();
        Console.WriteLine("CONSTRUCTORS: --------------------------------------------------------");
        /*
         Konstrukturite:
         
         */
        var constructors = type.GetConstructors();

        //ZNAEM CHE AKO NQMAME KONSTRUKTURI KOMPILATORA NI SUZDAVA EDIN ZA NAS AVTOMATICHNO.
        //OBACHE TUK NQMA DA GO VIDIM
        foreach (var ctor in constructors)
        {
            Console.WriteLine(ctor); //POKAZVA NI GI VUV SUShTIQ VID V KOITO SME GI NAPRAVILI.
        }




        Console.WriteLine();
        Console.WriteLine("INSTANCE: --------------------------------------------------------");

        /*
         Instancii:
            Mojem da gi suzdavame chrez reflection 
         */

        //Seg shte suzdadem obekti ot tip TestReflection SUS I BEZ PARAMETRI:

        var instanceNoParams = Activator.CreateInstance(typeof(ReflectionDemo.TestReflection));

        var instanceIntParam = Activator.CreateInstance(typeof(ReflectionDemo.TestReflection),
            new object[] { 10 });

        var instanceDoubleParam = Activator.CreateInstance(typeof(ReflectionDemo.TestReflection),
            new object[] { 10.3 });

        var instanceStringParam = Activator.CreateInstance(typeof(ReflectionDemo.TestReflection),
            new object[] { "Say Hello" });

        //REALNO MINAVAME PREZ RAZLICHNITE KONSTRUKTURI, SETNALI SME GO DA IZPISVA NA KONZOLATA V KOI KONSTRUCTOR SME.
        //Vijdame che mojem da suzdavame vsichko i tova ponqkoga e obasno.


        //SHte si suzdadem string builder.
        var sb = Activator.CreateInstance(Type.GetType("System.Text.StringBuilder"));

        //ZA DA GO POLZVAME TRQBVA DA GO KASTNEM:
        ((System.Text.StringBuilder)sb).AppendLine("hahhaTest");
        Console.WriteLine(sb);





        Console.WriteLine();
        Console.WriteLine("POLETA: --------------------------------------------------------");

        /*
            Reflection fields:

                Ima dva vida poleta:
                    Static fields  -  ZNAEM CHE SA Poleta na samiq klas, POLZVAME GI DIREKTNO OT KLASA.
                    Instance fields  -  POLETA ZA KOITO NI TRQBVA INSTANCIQ ZA DA GI POLZVAME.  
                
                Mojem da dostupvame statichni poleta na daden klas Chrez Reflection.   
         
         */

        Type type2 = typeof(ReflectionDemo.TestReflection);
        var fields = type2.GetFields();

        //VZIMA SAMO PUBLICHNITE POLETA, I NE VZIMA PROPERTITA
        foreach (var field in fields)
        {
            Console.WriteLine(field);
        }



        Console.WriteLine();
        Console.WriteLine("STATIC POLETA: --------------------------------------------------------");
        //KAK DA VZEMEM STATICHNITE POLETA  I KAZVAME CHE ISKAME PUBLICHNiTE
        var staticFields = type2.GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
        foreach (var field in staticFields)
        {
            Console.WriteLine(field);
        }



        Console.WriteLine();
        Console.WriteLine("INSTANCE POLETA: --------------------------------------------------------");

        //KAK DA VZEMEM INSTANSE POLETATA I KAZVAME CHE ISKAME PUBLICHNiTE
        var instanceFields = type2.GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var field in instanceFields)
        {
            Console.WriteLine(field);
        }




        Console.WriteLine();
        Console.WriteLine("PRIVATE POLETA: --------------------------------------------------------");

        //MOJEM DA VZEMEM VSICHKI PRIVATE I POLETA, instantichni i statichni:
        var privateFields = type2.GetFields(System.Reflection.BindingFlags.Instance |
            System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

        //VZIMA SAMO PUBLICHNITE POLETA, I NE VZIMA PROPERTITA
        foreach (var field in privateFields)
        {
            Console.WriteLine(field);
            //POKAZVAni I AVTOMATICHNOGENERIRANItE BACKING POLETA.
        }


        Console.WriteLine();
        Console.WriteLine(".GetField(FIELDNAME): --------------------------------------------------------");

        //VZIMAME VSICHKI PUBLIC POLETA EDIN PO EDIN
        //Mojem da vzimame samo edno PUBLICHNO pole ako iskame s .GetField("FIELDNAME")
        FieldInfo singlePublicField = type2.GetField("publicInstance");
        Console.WriteLine(singlePublicField.Name); //imeto na poleto
        Console.WriteLine(singlePublicField.FieldType);//Printirame i tipa na poleto

        //Mojm da vzimame i STATICHNITE POLETA
        FieldInfo singlePublicStaticField = type2.GetField("publicStatic");
        Console.WriteLine(singlePublicStaticField);


        //SLED KATO VZEMEM DADENO POLE MOJEM DA MU SETVAME STOINOST SUS .SetValue() OBACHE TRQBVA DA MU PODADEM I CELIQ OBEKT
        //ZA TOVA OBACHE NI TRQBVA 'FieldInfo' KOETO NI TURSI using System.Reflection;
        //TOVA E ZABRANENO ZASHTOTO MOJEM DA DOSTUPIM I DA SETVAME 'private' POLETA

        //singlePublicField.SetValue(type2, "Setnata stoinost");
        //Console.WriteLine(singlePublicField);
        //NESHTO NE STAWA


        Console.WriteLine();
        Console.WriteLine("Methods: --------------------------------------------------------");

        //VAAJNO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //.GetMethods()  VZIMAME METODITE, MOJEM DA VZIMAME I SAMO PO EDIN SPESIFICHEN METOD S .GetMethod("methodName");
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
        //Mojem da vzemem daden konstruktor po parametri i mojem ot samiq konstruktor da mu vzeme parametrite.
        //VZIMAME KONSTURKToR PO PARAMETRITE I GO INVOKCAME KATO MU PODAVAME TAKIVA:

        //01.Vzimame tipa na klasa StringBuilder
        Type currentType = typeof(StringBuilder);
        
        //02 vzimame si konstruktora koito priema primerno dva puti 'Int' :
        var intConstructor = currentType.GetConstructor(new Type[] { typeof(int), typeof(int) });

        //03.Invokvame go kato mu podavame masiv ot tip 'object' s dvata integera :
        var sb2 = intConstructor.Invoke(new object[] {5, 100});
        //VIJDA ME CHE IMA 'Capacity' = 5;  I  'MaxCapacity' = 100;    sinvola




        Console.WriteLine();
        Console.WriteLine("Invoking Methods: ----------------------------------------------");

        //Vzimame metoda Append ot StringBuilder i go izvikvame na nashiq obekt 'sb2' :

        //kazvame mu che iskame da priema samo edin argument i to 'string' zashtoto moje da imame mnogo Append metodi
        //Append() metoda na StringBUilder ima 20 'overloads' t.e. ima 20 metoda s imeto Append koito priemat razlichni parametri
        //i ne znae koit da ni dade zatova mu kazvame s newType(){...}
        var appendMethod = currentType.GetMethod("Append", new Type[] { typeof(string) });
        appendMethod.Invoke(sb2, new object[] { "append called" }); //pak go iska kato parametiur na obekt zashtoto ne znae kolko shte mu se podadat

        Console.WriteLine(sb2); // VIJDAME CHE IMA .Length 13 koeto e duljinata na "append called" 




        Console.WriteLine(); Console.WriteLine();
        //VAJNO!OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!
        //KATO CQLO REFLECtiON MNOGO POMAGA ZASHTOTO NI PREDOSTAVQ MNOGO NESHTA, MNOGO E BOGATO
        TestReflection tr = new TestReflection();
        //tr. + SPACE
        
        //VIJDAME CHE AKO NAPRAVIM NORMALEN OBEKT NA TOZI KLAS NQMA DA IMAME TOLKOVA OPCII.

        //ZA DA POLZVAME OBEKT SUZDADEN OT REFLECTION KATO NORMALEN TRQBVA DA GO KASTNEM
        var trTest = (TestReflection) Activator.CreateInstance(typeof(TestReflection));
        //trTest. + SPACE
        //SEGA VECHE MOGA DA MU POLZVAM NESHTATA !!!!!!!!!!!!!!!

        Console.WriteLine();
        Console.WriteLine($"Backing Fields:");
        Console.WriteLine($"Kogato imame samo property BEZ pole v daden klas, to kompiltora ni go suzdava avtomatichno !!!");

        /*
         Backing Fields:
            Kogato imame samo property BEZ pole v daden klas, to kompiltora ni go suzdava avtomatichno !!!
         
         */







        /*
         ATTRIBUTI:
            Vijdali sme gi v kursa Software Technoogies !!!!!    
        
        Dosega s Reflection chetohme danni ot nashte klasove kato:
            Tip na klasa, tip na parametrite, return tip na metod i dr METADANNI.

        NO IMA NACHIN DA DOBAVIM OSHTE METADANNI KUM DADEN KLAS, POLE, PROPERTY ILI METOD CHEREZ ATRIBUTI:
        Primerno ako imame metod i iskame toi da znae koi mu e avtora mojem da mu zakachim takuv atribut.
        
        Atributite sa dopulnitelni METADANNI za klasove ili metodi koito omjem da zakachame.
        Opisvat chasti ot nashiq kod.
        Mojem da si suzdadem nash si atribut.    

        VIJ KLASS Student PO DOLO, DOBAVENI SA ATRIBUTI NA PROPERTiTATA !!! 

        ...
        [DataMember(Name = "student_age")] //vkluchvame using System.Runtime.Serialization;
        public int Age { get; set; }
        //KOGATO EXPORtNEM PROEKTA (SERIALIZIRAME) TOV POLE SHTE SE VIJDA KATO "student_age"
        ...

        Primer:  
            [Obsolete] atributa na daden metod kazva da ne se polzva, toi moje da se polzva no 
                atributa e kato preduprejdenie da ne se polzva.

            [Flags] - tretirame metoda ili dr kato seriq ot BITOVI FLAGOVE, neshtata v nashiq metod
                se predstavqt v bitove.

            [DllImport("user32.dll", EntryPoint="...")] - Vkluchvame dadena biblioteka, AKO SUSHTESTVUVA
                v dadeno mqsto. IZVIKVAME DRUGA BIBLIOTEKA.

            ...
            IMA OSHtE MNOGO VIDOVE ATriBUTI
        
         
         
         
         ATRIBUTITE NOGAT DA PRIEMAT PARAMETRI ZA KONSTRUKTURI
         
         
         */








        /*
         Summary:
            01.Reflection e API koeto ni edadeno da si izsledvame koda.
                S nego mojem da pravim mnogo neshta kato da vzimame:
                    tipove,
                    medodi,  i da gi invokvame vurhu obekti
                    poleta,  i da gi setvame
                    proprtita,   i da gi setvame
                    construktori,    i da gi invokvame vurhu obekti
                Vajno e da zapomnim che trqbva da si parsvame obektite za da gi polzvame kato takiva.
         
            02.Attributes  -  Pozvolqva ti da slagash oshte metadnni kum klasove, metodi, poleta i dr.
                Ima BuildIn attributes no mojem i nie da si napravim 
                Tova e klas koito nasledqva Attribute i mu se kazv kak da bude polzvan i kakvo moje da pravi.

         
         */



    }


    class Student
    {
        public Student()
        {}

        public string Name { get; set; }

        [DataMember(Name = "student_age")] //vkluchvame using System.Runtime.Serialization;
        public int Age { get; set; }
        /*
            Sega ako ecportvame klasa tova shte se vijda kato student_age zashtoto taka sme
            go obqvili, NO PRI NAS SI OSTAVQ 'Age'

        */


        public string SayHello()
        {
            return $"Hello,my name is {this.Name} an I am {this.Age} years old.";
        }
    }

}

