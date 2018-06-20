// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    
    /*
    using FestivalManager.Core.Controllers;
    using FestivalManager.Core.Controllers.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Entities.Instruments;
    using FestivalManager.Entities.Sets;
    */
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
	public class SetControllerTests
    {
        private IStage stage;
        private ISetController setController;

        [SetUp]
        public void SetTests()
        {
            this.stage = new Stage();
            this.setController = new SetController(stage);
        }

      

        [Test]
        public void TestControllerParametersCount()
        {


            Type type = typeof(SetController);
            ConstructorInfo ctor = type.GetConstructors().First();
            ParameterInfo[] @params = ctor.GetParameters();

            //Proverqvame broqt im
            Assert.AreEqual(@params.Count(), 1);
            
        }


        [Test]
        public void TestControllerParametersType()
        {


            Type type = typeof(SetController);
            ConstructorInfo ctor = type.GetConstructors().First();
            ParameterInfo[] @params = ctor.GetParameters();
            
            //Proverqvame tipovete im
            Assert.AreEqual(@params[0].ParameterType.ToString(), "FestivalManager.Entities.Contracts.IStage");
        }


        
        [Test]
        public void TestPerformSetsEmpty()
        {
            Assert.AreEqual(setController.PerformSets(), string.Empty);
        }


        [Test]
        public void TestPerformSets()
        {


            ISet set = new Short("NewSet");
            IPerformer performer = new Performer("Perofrmer1", 10);
            ISong song = new Song("NewSong", new TimeSpan(0, 5, 5));

            stage.AddSet(set);
            stage.AddPerformer(performer);
            stage.AddSong(song);

            string result = setController.PerformSets();
            Assert.AreEqual(result, "1. NewSet:\r\n-- Did not perform");
        }




        [Test]
        public void TestPerformSetsSetDidNotPerform()
        {


            ISet set = new Short("NewSet");
            IPerformer performer = new Performer("Perofrmer1", 10);
            ISong song = new Song("NewSong", new TimeSpan(0, 5, 5));

            stage.AddSet(set);
            stage.AddPerformer(performer);
            stage.AddSong(song);

            string result = setController.PerformSets();
            Assert.AreEqual(result, "1. NewSet:\r\n-- Did not perform");
        }


        [Test]
        public void TestPerformSetsSetSuccessful()
        {
            
            ISet set = new Short("NewSet");

            IInstrument drum = new Drums();

            IPerformer performer = new Performer("Perofrmer1", 10);
            performer.AddInstrument(drum);

            ISong song = new Song("NewSong", new TimeSpan(0, 5, 5));

            set.AddPerformer(performer);
            set.AddSong(song);

            stage.AddSet(set);
            
            stage.AddPerformer(performer);
            stage.AddSong(song);

            string result = setController.PerformSets();
            Assert.AreEqual(result, "1. NewSet:\r\n-- 1. NewSong (05:05)\r\n-- Set Successful");
        }


        [Test]
        public void TestPerformSetsSetThrowsError()
        {

            ISet shortSet = new Short("shortSet");
            ISet longSet = new Long("longSet");
            ISet mediumSet = new Medium("mediumSet");

            IInstrument drum = new Drums();
            IInstrument guitar = new Guitar();
            IInstrument microphone = new Microphone();

            IPerformer nakov = new Performer("Nakov", 10);
            IPerformer vladi = new Performer("Vladi", 10);
            IPerformer bojo = new Performer("Bojo", 10);

            nakov.AddInstrument(drum);
            nakov.AddInstrument(guitar);
            nakov.AddInstrument(microphone);

            vladi.AddInstrument(guitar);
            vladi.AddInstrument(drum);

            bojo.AddInstrument(microphone);


            ISong song = new Song("NewSong", new TimeSpan(0, 5, 5));
            ISong song2 = new Song("NewSong2", new TimeSpan(52, 7, 5));
            ISong song3 = new Song("NewSong3", new TimeSpan(1, 1, 5));
            ISong song4 = new Song("NewSong4", new TimeSpan(5, 5, 5));

            shortSet.AddPerformer(bojo);
            shortSet.AddPerformer(nakov);
            shortSet.AddPerformer(vladi);

            mediumSet.AddPerformer(vladi);
            mediumSet.AddPerformer(nakov);
            mediumSet.AddPerformer(bojo);

            longSet.AddPerformer(vladi);
            longSet.AddPerformer(bojo);
            longSet.AddPerformer(nakov);


            shortSet.AddSong(song);
          
            
            Assert.Throws<InvalidOperationException>(() => { shortSet.AddSong(song2); });
        }

        [Test]
        public void TestPerformSetsSetSuccessfulMultipeSetsInstrumentsPerformersAndSongs()
        {

            ISet shortSet = new Short("shortSet");
            ISet longSet = new Long("longSet");
            ISet mediumSet = new Medium("mediumSet");

            IInstrument drum = new Drums();
            IInstrument guitar = new Guitar();
            IInstrument microphone = new Microphone();

            IPerformer nakov = new Performer("Nakov", 10);
            IPerformer vladi = new Performer("Vladi", 10);
            IPerformer bojo = new Performer("Bojo", 10);

            nakov.AddInstrument(drum);
            nakov.AddInstrument(guitar);
            nakov.AddInstrument(microphone);

            vladi.AddInstrument(guitar);
            vladi.AddInstrument(drum);

            bojo.AddInstrument(microphone);


            ISong song = new Song("NewSong", new TimeSpan(0, 5, 5));
            ISong song2 = new Song("NewSong2", new TimeSpan(0, 7, 5));
            ISong song3 = new Song("NewSong3", new TimeSpan(0, 1, 5));
            ISong song4 = new Song("NewSong4", new TimeSpan(0, 0, 5));

            shortSet.AddPerformer(bojo);
            shortSet.AddPerformer(nakov);
            shortSet.AddPerformer(vladi);

            mediumSet.AddPerformer(vladi);
            mediumSet.AddPerformer(nakov);
            mediumSet.AddPerformer(bojo);
            
            longSet.AddPerformer(vladi);
            longSet.AddPerformer(bojo);
            longSet.AddPerformer(nakov);


            shortSet.AddSong(song);
            shortSet.AddSong(song2);
            shortSet.AddSong(song3);
            shortSet.AddSong(song4);

            mediumSet.AddSong(song);
            mediumSet.AddSong(song2);
            mediumSet.AddSong(song3);
            mediumSet.AddSong(song4);

            longSet.AddSong(song);
            longSet.AddSong(song2);
            longSet.AddSong(song3);
            longSet.AddSong(song4);


            stage.AddSet(shortSet);
            stage.AddSet(mediumSet);
            stage.AddSet(longSet);

            stage.AddPerformer(nakov);
            stage.AddPerformer(bojo);
            stage.AddPerformer(vladi);

            stage.AddSong(song);
            stage.AddSong(song2);
            stage.AddSong(song3);
            stage.AddSong(song4);

            string result = setController.PerformSets();
            Assert.AreNotEqual(result, "1. shortSet:\r\n-- 1. NewSong (05:05)\r\n-- Set Successful\r\n2. mediumSet:\r\n-- Did not perform\r\n3. longSet:\r\n-- Did not perform");
        }


    }
}