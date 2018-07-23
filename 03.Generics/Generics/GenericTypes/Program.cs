using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>();
            list.Add(10);

            var list2 = new ArrayList();
            list2.Add(1);
            list2.Add("Dve");
            list2.Add(true);

            Console.WriteLine(list2[0]); 
            Console.WriteLine(list2[1]); 
            Console.WriteLine(list2[2]); 

            var type = list2[1].GetType().Name;
            Console.WriteLine(type);

            list2[1].ToString().IndexOf('v');

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
            Bag<Cat> bagOfCats = new Bag<Cat>();
            bagOfCats.AddItem(new Cat("Sisa", 15));
            bagOfCats.AddItem(new Cat("Garfild", 10));
            bagOfCats.AddItem(new Cat("Spaiky", 5));

            Console.WriteLine("Cat at index 1: " + bagOfCats.GetEmenementAtIndex(1));

            Console.WriteLine();
            var bagDict = new BagDictionary();
            bagDict.Add("Nasko", 25);
            bagDict.Add("Asi", 26);
            
            var tuple = (22, "Gosho", 5.55);
            (int age, string name, double grade) = tuple;

            Console.WriteLine();
            var pickleJar = new PickleJar();
            pickleJar.Add(new Pickle());
            pickleJar.Add(new Pickle());
            pickleJar.Add(new Pickle());

            foreach (var pickle in pickleJar.Items)
            {
                Console.WriteLine(pickle.Freshness);
            }

            Console.WriteLine();
            var cucumberJar = new CucumberJar();
            cucumberJar.Add(new Cucumber());
            cucumberJar.Add(new Cucumber());
            cucumberJar.Add(new Cucumber());

            foreach (var cucumber in cucumberJar.Items)
            {
                Console.WriteLine(cucumber.Freshness);
            }

            Console.WriteLine();
            var intList = CreateList<int>();

            intList.Add(1);
            intList.Add(2);
            intList.Add(3);
            intList.RemoveAt(0);
            Console.WriteLine(string.Join(", ", intList));

            Console.WriteLine();
          
            var referenceCollection = new ReferenceTypeCollections<string>();
           
            var valueCollection = new ValueTypeCollections<int>();
           
            var dictionaryCollection = new DictionaryTypeCollections<Dictionary<string, int>>();
			
			var catTypeCollection = new CatTypeCollections<Cat>();

            catTypeCollection.AddCat(new Cat("Gafy", 5));
            catTypeCollection.AddCat(new Cat("Asi", 25));
            catTypeCollection.AddCat(new Cat("Baba", 45));
            catTypeCollection.PrintInfo();
        }
  
        public static List<T> CreateList<T>()
        {
            return new List<T>();
        }
    }

    public class ReferenceTypeCollections<T>
        where T : class
    {}

    public class ValueTypeCollections<T>
        where T : struct 
    {}

    public class CatTypeCollections<T>
        where T : Cat 
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
    }

    public class DictionaryTypeCollections<T>
        where T : IDictionary<string, int> 
    {}
   
}