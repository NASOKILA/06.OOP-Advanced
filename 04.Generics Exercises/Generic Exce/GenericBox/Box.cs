using System;
using System.Collections.Generic;
using System.Text;


public class Box<T> 
    where T : IComparable<T>

{
    public Box(T value)
    {
        this.value = value;
    }

    private T value { get; set; }

    public override string ToString()
    {
        return $"{this.value.GetType().FullName}: {this.value}";
    }


    public static int Compare(List<Box<T>> listOfBoxes, Box<T> comparableBox)
    {
        int count = 0;

        for (int i = 0; i < listOfBoxes.Count; i++)
        {
            var currentBox = listOfBoxes[i];
            if (currentBox.value.CompareTo(comparableBox.value) > 0)
                count++;
        }

        return count;
    }

}

