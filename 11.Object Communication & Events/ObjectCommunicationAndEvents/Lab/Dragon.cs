using System;
using System.Collections.Generic;

public class Dragon : IObservableTarget
{
    private const string THIS_DIED_EVENT = "{0} dies";

    private string id;
    private int hp;
    private int reward;
    private bool eventTriggered;
    private Logger logger;
    private List<IObserver> observers;

    public Dragon(string id, int hp, int reward, Logger logger)
    {
        this.observers = new List<IObserver>();
        this.logger = logger;
        this.id = id;
        this.hp = hp;
        this.reward = reward;
    }

    public bool IsDead { get => this.hp <= 0; }
    
    public void ReceiveDamage(int damage)
    {
        if (!this.IsDead)
        {
            this.hp -= damage;
        }

        if(this.IsDead && !eventTriggered)
        {
            Console.WriteLine(THIS_DIED_EVENT, this);
            this.NotifyObservers();
            this.eventTriggered = true;
        }
    }

    public override string ToString()
    {
        return this.id;
    }

    public void NotifyObservers()
    {
        if (this.IsDead)
        {
            this.observers.ForEach(o => o.Update(this.reward));
        }
    }
    public void Register(IObserver observer)
    {
        if (!this.observers.Contains(observer))
        {
            this.observers.Add(observer);
        }
    }

    public void Unregister(IObserver observer)
    {

        if (this.observers.Contains(observer))
        {
            this.observers.Remove(observer);
        }
    }

    public void Update(int number)
    {
        throw new NotImplementedException();
    }
}
