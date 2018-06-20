using NUnit.Framework;
using System;

//Mahame namespace-a i si dobavqme refereniq ruchno kum proekta koito shte testvame
//Instalirame si NUnit, NUnit3TestAdapter i Microsoft.Net.Test.Sdk 
public class AxeTests
{


    //SLEDVAME DOBRITE PRAKTIKI I SI PRAVIM KONSTANTI
    private const int axeAttackPoints = 10;
    private const int axeDurabilityPoints = 11;
    private const int axeExpectedDurabilityPoints = 10;
    private const int dummyHealth = 10;
    private const int dummyExperience = 10;

    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void InitializeTests() //Shte se izpulni predi vseki test
    {
        this.axe = new Axe(axeAttackPoints, axeDurabilityPoints); 
        this.dummy = new Dummy(dummyHealth, dummyExperience);
    }


    [Test]
    public void WeaponLosesDurabilityAfterEachAttack()
    {

        //ACT
        //atakuvame 
        axe.Attack(dummy);

        //ASSERT
        //durabilitito na Axe trqbva da e padnalo s edno
        Assert.That(axe.DurabilityPoints, Is.EqualTo(axeExpectedDurabilityPoints), 
            "Axe Durability does not change after attack !");
    }

    [Test]
    public void AttackWithBrokenWeapon()
    {

        int brokenAxeValue = -1;

        //SHTE GO VZEMA S REFLEKTION I SHTE MU PROMENA DURABILITY POINTS NA -1 ZA DA ROVERIM DALI BRADVATA E SCHUPENA
        var axeDurabilityPointsReflection = axe.GetType().GetField("durabilityPoints",
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Static |
            System.Reflection.BindingFlags.Instance);

        //Vzehme private poleto durability points i go setnahme na -1
        axeDurabilityPointsReflection.SetValue(axe, brokenAxeValue);


        //ACT & ASSERT
        //Trqbva da hvurli exception zashtoto ne moje durability points da e < 0
        //MOJEM DA SI TESTVAME DAJE KAKVU EXEPTION SHTE HVURLI.
        Assert.That(() => axe.Attack(dummy), 
            Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));

        //AKO SUOBSHTENIETO NI E GRESHNO KPAK SHTE GRUMNE.

    }

}

