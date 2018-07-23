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
    public void initializeTest() 
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

        var health = this.dummy.GetType().GetField("health",
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Static |
            System.Reflection.BindingFlags.Instance);

        health.SetValue(this.dummy, deadDummyHealth);

        Assert.That(() => dummy.TakeAttack(this.pointsTaken),
            Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void DeadDummyCanGiveXP()
    {
        int deadDummyHealth = 0;

        var health = this.dummy.GetType().GetField("health",
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Static |
            System.Reflection.BindingFlags.Instance);

        health.SetValue(this.dummy, deadDummyHealth);

        int givenExperience = dummy.GiveExperience();

        Assert.That(givenExperience, Is.EqualTo(this.initialExp));
    }

    [Test]
    public void AliveDummyCantGiveXP()
    {    
        Assert.That(() => dummy.GiveExperience(),
            Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }
}