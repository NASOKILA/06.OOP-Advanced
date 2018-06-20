using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            
            /*
             LEKCIQ GENERIC TYPES:

             Generic typove ushtestvuvat ot C# 2 nasam, predi tova e nqmalo,
             Mojem da imame dadena funkcionalnost koqto da raboti sus vsichki tipove danni.
             */

            //Mojem da napravim spisuk sus kakvoto i da e obache sled tova mojem da slagame samo posocheniq tip vutre
            var list = new List<int>();
            list.Add(10);
            //list.Add("Edinadeset");  // ne mojem trqbva da slagame samo intove


            //VAJNO!!!!  V ArrayList() mojem da slagame kakvoto si poiskame
            var list2 = new ArrayList();
            list2.Add(1);
            list2.Add("Dve");
            list2.Add(true);

            Console.WriteLine(list2[0]); //1
            Console.WriteLine(list2[1]); //Dve
            Console.WriteLine(list2[2]); //true

            //KAZVA MI CHE E STRING OBACHE ZA KOMPILATORA E 'Object' SLEDOVATELNO NE MOJEM DA POLZVAME VSICHKO OT String
            var type = list2[1].GetType().Name;
            Console.WriteLine(type);


            //list2[1].IndexOf('v');  //NE MOJEM

            //ZA DA GO POLZVAM TOCHNO KATO STRING TRQBVA DA GO KASTNA.
            list2[1].ToString().IndexOf('v');

            //Vmesto da go kastvame vseki put mojem da polzvame GENERIC zashtoto e MNOGO PO BURZO.


            //TRQBVA DA SI NAPRAVIM GENERIC KLAS 
            //Napravihme si Bag klas koito da raboti sus vsichki tipove, VIJ KLASA 'Bag' !!!
            Console.WriteLine();
            Bag<int> bagOfIntegers = new Bag<int>();
            bagOfIntegers.AddItem(1);
            bagOfIntegers.AddItem(2);
            bagOfIntegers.AddItem(3);

            Console.WriteLine("Index at 1: " + bagOfIntegers.GetEmenementAtIndex(1));
            bagOfIntegers.RemoveItem(3);
            Console.WriteLine("All INTEGER items: " + bagOfIntegers);

            Console.WriteLine();
            Bag<string> bagOfStrings = new Bag<string>();
            bagOfStrings.AddItem("One");
            bagOfStrings.AddItem("Two");
            bagOfStrings.AddItem("Tri");

            Console.WriteLine("Index at 1: " + bagOfStrings.GetEmenementAtIndex(1));
            bagOfStrings.RemoveItem("Tri");
            Console.WriteLine("All STRING items: " + bagOfStrings);


            Console.WriteLine();
            Bag<bool> bagOfBoolean = new Bag<bool>();
            bagOfBoolean.AddItem(true);
            bagOfBoolean.AddItem(false);
            bagOfBoolean.AddItem(true);
            bagOfBoolean.AddItem(false);

            Console.WriteLine("Index at 1: " + bagOfBoolean.GetEmenementAtIndex(1));
            bagOfBoolean.RemoveItem(true);
            Console.WriteLine("All BOOLEAN items: " + bagOfBoolean);


            Console.WriteLine();
            //Mojem da go polzvame i s klasove napraveni ot nas
            Bag<Cat> bagOfCats = new Bag<Cat>();
            bagOfCats.AddItem(new Cat("Sisa", 15));
            bagOfCats.AddItem(new Cat("Garfild", 10));
            bagOfCats.AddItem(new Cat("Spaiky", 5));

            Console.WriteLine("Cat at index 1: " + bagOfCats.GetEmenementAtIndex(1));



            /*
             Type Safe i Type Unsafe ezicite:
                Type unsafe ezik e JavaScript i Pyton zashtoto nqma typizaciq,
                no v type safe ezik kato C# NE MOJEM.

             */



            //Generic tipovete se polzvat poveche ot hora koito pishat razni pbiblioteki i podobni.        



            /*
               Mojem da imame Generic klas sus nqkolko generic parametri PRIMERNO 'Dictionary' !!!!
               VIJ KLASA BagDictionary() KOITO NASLEDQVA Dictionary<> I RABOtI BEZ PROBLEM !!!
            */
            Console.WriteLine();
            var bagDict = new BagDictionary();
            bagDict.Add("Nasko", 25);
            bagDict.Add("Asi", 26);
            
                


            //VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!
            //KAKVO E Value Tuple ?  
            //Mojem dago polzvame za destrukturirane:  TOVA E IZMISLENO V C# 7
            var tuple = (22, "Gosho", 5.55);
            (int age, string name, double grade) = tuple;




            //VAJNOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //NQMA RAZLIKA MEJDU private readonly List<T> Items;  I   private List<T> Items { get; }




            /*  
                Mojem da imame klas koito nasledqva Generic klas i da go polzvame kato mu podadem typ !!!
                MOJEM DA IMAME I GENERIC KLAS KOITO DA NASLEDQVA GENERIC INTERFEISI, 
                Vij Jar<T> i IJar<T>.
                Mojem da imame klas PiccleJar koito da nasledqva Jar<T> I vmesto T da mu slagame klas Picle !!!
                
                
             */

            Console.WriteLine();
            var pickleJar = new PickleJar();
            pickleJar.Add(new Pickle());
            pickleJar.Add(new Pickle());
            pickleJar.Add(new Pickle());

            foreach (var pickle in pickleJar.Items)
            {
                //dava ni 50 na vsichki koeto e pravilno
                Console.WriteLine(pickle.Freshness);
            }




            //Sushtoto mojem da napravim i za CUcumber
            Console.WriteLine();
            var cucumberJar = new CucumberJar();
            cucumberJar.Add(new Cucumber());
            cucumberJar.Add(new Cucumber());
            cucumberJar.Add(new Cucumber());

            foreach (var cucumber in cucumberJar.Items)
            {
                //dava ni 100 na vsichki koeto e pravilno
                Console.WriteLine(cucumber.Freshness);
            }





            //VAJNOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!
            //.AsReadOnly() vrushta ReadOnlyColection();


            /*
             Generic metodi:
                Rabotat po sushtiq nachin kato Generic klasovete.


             */
            Console.WriteLine();
            var intList = CreateList<int>();

            intList.Add(1);
            intList.Add(2);
            intList.Add(3);
            intList.RemoveAt(0);
            Console.WriteLine(string.Join(", ", intList));





            //VAJNO!!!!!!!!!!!!!!!!!!
            //static e kakto v JS, zakachame metoda kum SAMIQ KLAS i NE ni trqbva instanciq za da go polzvame.

            //DnSpy:
            //Tova e dekompilator v koito pishem nqkkuv kod i gledame kak tochno se kompilira
            //E KATO VISUAL STUDIO I SE POLZVA ZA KOMPILIRANE NA KOD, MOJEM DA VIDIM TOCHNO KAK SE KOMPILIRA KOD.
            //Polzva nqkkuv drug ezik za kompilaciq






            Console.WriteLine();
            /*
             Generic Constraints:
                Genericite sa hubavi obache ni davat mnogo svoboda, shte razgleame nachin da gi
                ogranichim tipovete koito mojem da slagame. 
               
                MNOOOOOOOOOGOOOOOOOOO VAAAAJNNNNNNNNNNNOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!
                    Vsichki referentni tipove a 'class' 
                    a vsichki stoinostni tipove (int, double, long ...) sa 'struct'



                Ima nqkolko vida restrikcii:
                POLZVAIKI 'where : ' KAZVAME KAKVO TRQBVA DA NASLEDQVA NASHIQ KLAS
                    public class ClassName<T>
                        where T : struct
                    {}
                    //SUS 'where : ' MOJEM DA NASLEDQVAME SAMO PO EDIN KLAS NO PO MNOGO INTERFEISI
             
                
                MOJEM DA IMAME NQKOLKO PARAMETURA KOITO VSEKI EDIN DA SI IMA SOBSTVEN KONSTRAINT.
             
             */

            var referenceCollection = new ReferenceTypeCollections<string>();
            //var collection2 = new ReferenceTypeCollections<int>();     // NE MOJEM ZASHTOTO 'int' NE E REFERENTEN TIP

            
            var valueCollection = new ValueTypeCollections<int>();
            // var valueCollection2 = new ValueTypeCollections<string>();   //SUS string NE MI DAVA !!!  
            

            //Moga da go polzvam samo ako mu podam slednoto:
            var dictionaryCollection = new DictionaryTypeCollections<Dictionary<string, int>>();


            //VAJNO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //raboti samo s Cat klas koito sudadohme predi I MOJEM DA POLZVAME NESHTATA OT NEGO 
            var catTypeCollection = new CatTypeCollections<Cat>();

            catTypeCollection.AddCat(new Cat("Gafy", 5));
            catTypeCollection.AddCat(new Cat("Asi", 25));
            catTypeCollection.AddCat(new Cat("Baba", 45));
            catTypeCollection.PrintInfo();


            /*
             Summary:
                01.ArrayList() e udoben za polzvane obache trqbva da kasvame neshtata 
                    (koeto e BAVNA OPERACIQ) zashtoto kompilatora gi priema za obekti,
                    Mojem dago kastnem kato mu vvzememe typa hrez reflektion, sus GetType().Name

                02.Mojem da imame Generic Klas koito da priema nqkolko generic typove, kakto e 
                    Func<> !!!!!

                03.Value Tuple: Mojem da go polzvame za Destrukturirane

                04.Mojem da imame Generic klasove koito da nasledqvat generic interfeisi
             
                05.Ima i Generic metodi koito se polzvat po sushtiq nachin, mojem da imame klas 
                    koito da vrushta generik metod.

                06.Generic Constraints:  'where : ...'  Kazvame mu koi klasove da nasledqva
                    sledovatelno s koit tipove da raboti. VIJ klasa ReferenceTypeCollections<T> po dolo.
             */

        }





        //Generic metodite Rabotat po sushtiq nachin kato Generic klasovete.       
        public static List<T> CreateList<T>()
        {
            //suzdavame generic list
            return new List<T>();
        }


    }

    /*MOJEM DA SLAGAME RESTRIKCII VURHU KAKVI TIPOVE DA RABOTI NASHIQ GENERIC KLAS:
     V SLUCHAQ KAZVAME CHE MOJE DA SLAGAME SAMO REFERENTNI TIPOVE*/
    public class ReferenceTypeCollections<T>
        where T : class
    {
        //Vsichki referentni tipove a 'class' 
        //a vsichki stoinostni tipove (int, double, long ...) sa 'struct'
        //Sega nqmq da mojem da polzvame stoinostni tipove v tozi klas

    }


    public class ValueTypeCollections<T>
        where T : struct //MOJEM DA NASLEDQVAME SAMO PO EDIN KLAS NO MNOGO INTERFEISI
    {
        //Sega mojem da polzvame samo stoinostni tipove za tozi generic klas, t.e.
        // int, double, float, decimal, long, byte ...
    }

    public class CatTypeCollections<T>
        where T : Cat //tova raboti samo s Cat klasa
    {
        private List<Cat> BagOfCats { get; } = new List<Cat>();
        
        public void AddCat(Cat cat)
        {
            this.BagOfCats.Add(cat);
        }

        public void PrintInfo() {
            foreach (Cat cat in this.BagOfCats)
            {
                Console.WriteLine($"Name: {cat.Name} / Age: {cat.Age}");
            }
            
        }
        //Sus 'where : ' Mojem da nasledqvame mnogo interfeisi ili nqkoi BAZOV KLAS NA MESHto
    }

    public class DictionaryTypeCollections<T>
        where T : IDictionary<string, int> //tova raboti samo s Dictionary<string, int>
    {
            //Sus 'where : ' Mojem da nasledqvame mnogo interfeisi
    }

    //MOJEM DA SLOJIM DA NASLEDQVA Bazov Klas NA NESHTO

}






