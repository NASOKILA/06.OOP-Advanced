using System;
using System.Collections.Generic;
using System.Text;


/*
 Create attribute SoftUni with a string element called name, that:
	Can be used over classes and methods
	Allow multiple attributes of same type

 
  Sudavame si atributa:
    Purvo toi trqbva da na sledqva klasa Attribute, posle trqbva da se kaje kak da se izpolzva chrez dobavqne na drug atribut
    kazvame mu che shte bude izpolzvan vurhu klasove i metodi, i che mojem da imame mnogo atributi ot sushtiq tip.
 */

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class SoftUniAttribute : Attribute
{
    public SoftUniAttribute(string name)
    {
        this.Name = name;
    }

    public string Name { get; private set; }
}
