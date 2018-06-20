using System;
using System.Collections.Generic;
using System.Text;


public interface IJar<T>
{
    void Add(T element);

    T Remove();

    int Count { get; }
}

