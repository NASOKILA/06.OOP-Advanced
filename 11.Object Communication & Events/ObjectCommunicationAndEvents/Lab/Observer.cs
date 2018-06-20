using System;
using System.Collections.Generic;
using System.Text;


public class Observer : IObserver
{
    private int reward;

    public Observer()
    {
        this.reward = 0;
    }

    public void Update(int reward)
    {
        this.reward += reward;
    }
}

