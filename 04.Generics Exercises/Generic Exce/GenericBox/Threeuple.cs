using System;
using System.Collections.Generic;
using System.Text;


public class Threeuple<T, U, H> : Tuple<T, U>
{
    public Threeuple(T item1, U item2, H item3) 
        : base(item1, item2)
    {
        this.item3 = item3;
    }


    private H item3 { get; set; }

    public override string Print()
    {
        return $"{base.item1} -> {base.item2} -> {this.item3}";
    }


}

