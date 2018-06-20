using System;
using System.Collections.Generic;
using System.Text;

//nasledqva Cucumber i mu prezapisva edno virtualno property 
public class Pickle : Cucumber
{
    public override int Freshness { get; set; } = 50;
}

