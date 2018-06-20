using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {

        /*
         LinkedList
            Tova e spisuk v koito dobavqneto e po burzo i vseki element znae za 
            sledvashtiq element.
            Iteriraneto mu e po bavno zashtoto elementite se skladirat na razlichni mesta
            v pameta.
         
            POLZVA SE AKO ISKAME SAMO DA DOBAVQME I DA MAHAME; TOVA E NAI BURZIq VARIANT
         */

        //
        // Create a new linked list object instance.
        //
        LinkedList<string> linked = new LinkedList<string>();
        //
        // Use AddLast method to add elements at the end.
        // Use AddFirst method to add element at the start.
        //
        linked.AddLast("cat");
        linked.AddLast("dog");
        linked.AddLast("man");
        linked.AddFirst("first");
        //
        // Loop through the linked list with the foreach-loop.
        //
        foreach (var item in linked)
        {
            Console.WriteLine(item);
        }

        //ELEMENTITE VZIMAT MALKO POVECHE PAMET
        //MOJEM I DA MAHAME ELEMENTI 


    }
}

