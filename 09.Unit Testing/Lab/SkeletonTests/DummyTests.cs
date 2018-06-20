using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;


public class DummyTests
{
    private int pointsTaken = 5;
    private int initialHealth = 10;
    private int initialExp = 10;

    private Dummy dummy;

    [SetUp]
    public void initializeTest() //Shte se izpulni predi vseki test
    {
        this.dummy = new Dummy(initialHealth, initialExp);
    }

    [Test]
    public void DummyLosesHealthIfAttacked()
    {
        dummy.TakeAttack(pointsTaken);
        Assert.That(dummy.Health, Is.EqualTo(this.initialHealth - this.pointsTaken));
    }

    
    [Test]
    public void DeadDummyThrowsExceptionIfAttacked()
    {
        int deadDummyHealth = 0;

        //Vzimame s Reflection private health i go setvame na 0 za da bude murtav 'dummy'
        var health = this.dummy.GetType().GetField("health",
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Static |
            System.Reflection.BindingFlags.Instance);

        health.SetValue(this.dummy, deadDummyHealth);

        //ACT & ASSERT
        Assert.That(() => dummy.TakeAttack(this.pointsTaken),
            Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }

    
    [Test]
    public void DeadDummyCanGiveXP()
    {
        int deadDummyHealth = 0;

        //Vzimame s Reflection private health i go setvame na 0 za da bude murtav 'dummy'
        var health = this.dummy.GetType().GetField("health",
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Static |
            System.Reflection.BindingFlags.Instance);

        health.SetValue(this.dummy, deadDummyHealth);

        //ACT
        int givenExperience = dummy.GiveExperience();

        //ASSERT
        Assert.That(givenExperience, Is.EqualTo(this.initialExp));
    }

    
    [Test]
    public void AliveDummyCantGiveXP()
    {
        
        //ACT & ASSERT
        Assert.That(() => dummy.GiveExperience(),
            Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }

}

