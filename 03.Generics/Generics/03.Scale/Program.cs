using System;

class Program
{
    static void Main(string[] args)
    {
        var scale = new Scale<string>("Toni", "Toni");
        Console.WriteLine(scale.GetHeavier());

        var scale2 = new Scale<int>(55, 55);
        Console.WriteLine(scale2.GetHeavier());
    }
}

public class Scale<T>
   where T : IComparable<T>
{

    public Scale(T left, T right)
    {
        this.left = left;
        this.right = right;
    }

    private readonly T left;
    private readonly T right;

    public T GetHeavier()
    {
        // .CompareTo() - ako i dvete sa ravni vrushta 0 ako lqvoto e po malko vrushta -1 ako e po golqmo vrushta 1
        if (this.left.CompareTo(this.right) > 0)
            return this.left;

        else if (this.left.CompareTo(this.right) < 0)
            return this.right;

        //Vrushtame default(T) koeto shte bude null za strukturire
        return default(T);
    }

}


