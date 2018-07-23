using NUnit.Framework;
using System;


public class AxeTests
{
    private const int axeAttackPoints = 10;
    private const int axeDurabilityPoints = 11;
    private const int axeExpectedDurabilityPoints = 10;
    private const int dummyHealth = 10;
    private const int dummyExperience = 10;

    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void InitializeTests() 
    {
        this.axe = new Axe(axeAttackPoints, axeDurabilityPoints); 
        this.dummy = new Dummy(dummyHealth, dummyExperience);
    }

    [Test]
    public void WeaponLosesDurabilityAfterEachAttack()
    {
        axe.Attack(dummy);

        Assert.That(axe.DurabilityPoints, Is.EqualTo(axeExpectedDurabilityPoints), 
            "Axe Durability does not change after attack !");
    }

    [Test]
    public void AttackWithBrokenWeapon()
    {
        int brokenAxeValue = -1;

        var axeDurabilityPointsReflection = axe.GetType().GetField("durabilityPoints",
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Static |
            System.Reflection.BindingFlags.Instance);

        axeDurabilityPointsReflection.SetValue(axe, brokenAxeValue);

        Assert.That(() => axe.Attack(dummy), 
            Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    }
}