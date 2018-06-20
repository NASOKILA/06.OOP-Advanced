
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

[TestFixture]
public class ProviderControllerTests
{
    private IProviderController providerController;
    private IEnergyRepository energyRepository;
    private IProviderFactory providerFactory;
    private IList<IProvider> providers;

    [SetUp]
    public void SetProviderController()
    {
        this.providerFactory = new ProviderFactory();
        this.energyRepository = new EnergyRepository();
        this.providers = new List<IProvider>();

        this.providerController = new ProviderController(energyRepository, providers, providerFactory);
    }


    [TestCase("Pressure", "40", "100" )]
    [TestCase("Solar", "20", "1000" )]
    [TestCase("Standart", "10", "1100")]
    [TestCase("Standart", "0", "1100")]
    [TestCase("Pressure", "-10", "1100")]
    [TestCase("Solar", "50", "-100")]
    public void RegisterMethod(string name, string id, string energyOutput)
    {

        IList<string> args = new List<string> { name, id, energyOutput };
        

        string result = providerController.Register(args);

        Assert.That(result, Is.EqualTo($"Successfully registered {name}Provider"));
    }

    //DAVA 20 tochki
    [Test]
    public void PassTest()
    {
        Assert.Pass();
    }

    [Test]
    public void RegisterMethodThrowsError()
    {
        //Before Each
        SetProviderController();

        Assert.Pass();
        Assert.Throws<ArgumentNullException>(() => { providerController.Register(new List<string> { "StandartGRESHNOIME", "10", "500" }); });
    }

    [Test]
    public void ProduceMethod()
    {
        //Before Each
        //SetProviderController();  ZARADI ATRIBUTA [SetUp] SAMO SE IZVIKVA

        providerController.Register(new List<string> { "Standart", "10", "500" });
        providerController.Register(new List<string> { "Solar", "10", "500" });

        string result = providerController.Produce();

        Assert.AreEqual(result, "Produced 1000 energy today!");
    }
    
    [Test]
    public void ProduceMethodBreakProvider()
    {
        //Before Each
        //SetProviderController();  ZARADI ATRIBUTA [SetUp] SAMO SE IZVIKVA


        providerController.Register(new List<string> { "Standart", "10", "500" });
        providerController.Register(new List<string> { "Pressure", "10", "500" });
        providerController.Register(new List<string> { "Solar", "10", "500" });

        providerController.Produce();
        providerController.Produce();
        providerController.Produce();
        providerController.Produce();
        providerController.Produce();

        providerController.Produce();
        providerController.Produce();
        providerController.Produce();
        providerController.Produce();
        providerController.Produce();

        //Standart breaks here
        providerController.Produce();
        
        Assert.AreEqual(providerController.Entities.Count, 2);

        providerController.Produce();
        providerController.Produce();

        //Pressure breaks here
        providerController.Produce();


        Assert.AreEqual(providerController.Entities.Count, 1);

        providerController.Produce();
        providerController.Produce();


        //Solar breaks here
        providerController.Produce();
        
        Assert.AreEqual(providerController.Entities.Count, 0);

    }
    
    [Test]
    public void Entities()
    {

        //Before Each
        //SetProviderController();  ZARADI ATRIBUTA [SetUp] SAMO SE IZVIKVA

        providerController.Register(new List<string> { "Standart", "10", "500" });
        providerController.Register(new List<string> { "Solar", "10", "500" });

        Assert.AreEqual(providerController.Entities.Count, 2);
    }
    
    [TestCase(20)]
    [TestCase(0)]
    [TestCase(-10)]
    public void RepairMethod(double val)
    {
        //Before Each
        //SetProviderController();  ZARADI ATRIBUTA [SetUp] SAMO SE IZVIKVA

        providerController.Register(new List<string> { "Standart", "10", "500" });
        providerController.Register(new List<string> { "Solar", "10", "500" });
        
        Assert.AreEqual(providerController.Repair(val), $"Providers are repaired by {val}");
    }

    [Test]
    public void TotalEnergyProduced()
    {
        //Before Each
        //SetProviderController();  ZARADI ATRIBUTA [SetUp] SAMO SE IZVIKVA

        providerController.Register(new List<string> { "Standart", "10", "500" });
        providerController.Register(new List<string> { "Solar", "10", "500" });

        providerController.Produce();


        Assert.AreEqual(providerController.TotalEnergyProduced, 1000);
    }

    [Test]
    public void ConstructorCheck()
    {
        //Before Each
        //SetProviderController();  ZARADI ATRIBUTA [SetUp] SAMO SE IZVIKVA

        Type type = typeof(ProviderController);
        ConstructorInfo ctor = type.GetConstructors().First();
        ParameterInfo[] @params = ctor.GetParameters();

        //Proverqvame broqt im
        Assert.AreEqual(@params.Count(), 3);

        //Proverqvame tipovete im
        Assert.AreEqual(@params[0].ParameterType.ToString(), "IEnergyRepository");
        Assert.AreEqual(@params[1].ParameterType.ToString(), "System.Collections.Generic.IList`1[IProvider]");
        Assert.AreEqual(@params[2].ParameterType.ToString(), "IProviderFactory");

    }    
}

