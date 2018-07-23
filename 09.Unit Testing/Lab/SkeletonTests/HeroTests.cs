using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

public class HeroTests
{
    [Test]
    public void TestIfHeroGainsXP_WhenTargetDies_WithFakeClasses()
    {
        ITarget dummy = new FakeDummy();
        IWeapon weapon = new FakeWeapon();

        Hero hero = new Hero("Nasko", weapon);
        hero.Attack(dummy);
        Assert.That(hero.Experience, Is.EqualTo(20));
    }

    [Test]
    public void TestIfHeroGainsXP_WhenTargetDies_WithMochingFramwork()
    {
        Mock<ITarget> fakeTarget = new Mock<ITarget>();
        
        fakeTarget.Setup(t => t.Health).Returns(0);
        fakeTarget.Setup(t => t.IsDead()).Returns(true);
        fakeTarget.Setup(t => t.GiveExperience()).Returns(10);

        Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();

        Hero hero = new Hero("Nasko", fakeWeapon.Object);
        hero.Attack(fakeTarget.Object);

        fakeWeapon.Verify(w => w.Attack(fakeTarget.Object));

        Assert.That(hero.Experience, Is.EqualTo(10));         
    }
}

public class FakeWeapon : IWeapon
{
    private int attackPoints = 20;
    private int durabilityPoints = 10;

    public int AttackPoints => attackPoints;
    public int DurabilityPoints => durabilityPoints;
    
    public void Attack(ITarget target)
    {
        if (this.DurabilityPoints <= 0)
        {
            throw new InvalidOperationException("Axe is broken.");
        }

        target.TakeAttack(AttackPoints);
        this.durabilityPoints -= 1;
    }
}


public class FakeDummy : ITarget
{
    private int health = 0;

    public int Health => health;

    public int GiveExperience()
    {
        return 20;
    }

    public bool IsDead()
    {
        return true;
    }

    public void TakeAttack(int attackPoints)
    {
        if (this.IsDead())
        {
            this.health -= attackPoints;
        }    
    }
}