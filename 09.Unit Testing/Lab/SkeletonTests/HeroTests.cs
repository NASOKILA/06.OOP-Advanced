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
        //pravim si murtviq target sus Mock framework
        Mock<ITarget> fakeTarget = new Mock<ITarget>();
        
        //setvame Health na 0, IsDead() na true, i GiveExperience() na 20 !!!
        fakeTarget.Setup(t => t.Health).Returns(0);
        fakeTarget.Setup(t => t.IsDead()).Returns(true);
        fakeTarget.Setup(t => t.GiveExperience()).Returns(10);

        Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();

        Hero hero = new Hero("Nasko", fakeWeapon.Object);
        hero.Attack(fakeTarget.Object);

        fakeWeapon.Verify(w => w.Attack(fakeTarget.Object));
        //VERIFICIRAME CHE METODA .Attack() SE E IZVIKAL S fakeTargeta.
        //ZA DA MINE TESTA TRQBVA PURVO DA IZVIKAME Attack(fakeTarget.Object) 
        //hero.Attack(fakeTarget.Object); GO PRAVI AVTOMATICHNO



        Assert.That(hero.Experience, Is.EqualTo(10));
    
            
    }
}

//pravim si falshivo orujie
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


//Pravim si fashivo murtvo dummy
public class FakeDummy : ITarget
{
    //kruvta mu e 0
    private int health = 0;

    public int Health => health;

    //dava 20 experience
    public int GiveExperience()
    {
        return 20;
    }

    //murtav e 
    public bool IsDead()
    {
        return true;
    }

    //ne moje da poema ataki
    public void TakeAttack(int attackPoints)
    {
        if (this.IsDead())
        {
            //Pravim go ako e murtav da vrushta tochkite
            this.health -= attackPoints;
        }
        
    }
}

