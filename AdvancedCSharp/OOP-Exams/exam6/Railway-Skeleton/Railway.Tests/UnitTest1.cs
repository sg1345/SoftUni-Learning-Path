namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Tests
    {
        private const string name = "TestName";
        private const string trainInfo = "TestTrainInfo";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_Constructor()
        {
            RailwayStation railwayStation = new RailwayStation(name);

            Assert.AreEqual(name, railwayStation.Name);
            Assert.AreEqual(0, railwayStation.ArrivalTrains.Count);
            Assert.AreEqual(0, railwayStation.DepartureTrains.Count);
        }

        [TestCase(null), TestCase(" ")]
        public void Test_Name_IsNotNullOrWhiteSpace_ArgumentException(string NotAllowedName)
        {
            Assert.Throws<ArgumentException>(() => new RailwayStation(NotAllowedName));
        }

        [Test]
        public void Test_NewArrivalOnBoard()
        {
            RailwayStation railwayStation = new RailwayStation(name);

            railwayStation.NewArrivalOnBoard(trainInfo);

            Assert.AreEqual(trainInfo, railwayStation.ArrivalTrains.Peek());

            railwayStation.NewArrivalOnBoard(trainInfo + "1");

            Assert.AreEqual(trainInfo, railwayStation.ArrivalTrains.Peek());
        }

        [Test]
        public void Test_TrainHasArrive()
        {
            RailwayStation railwayStation = new RailwayStation(name);

            railwayStation.NewArrivalOnBoard(trainInfo);

            Assert.AreEqual($"There are other trains to arrive before {trainInfo + "1"}.", railwayStation.TrainHasArrived(trainInfo + "1"));

            Assert.AreEqual($"{trainInfo} is on the platform and will leave in 5 minutes.", railwayStation.TrainHasArrived(trainInfo));

            Assert.AreEqual(0, railwayStation.ArrivalTrains.Count);
            Assert.AreEqual(1, railwayStation.DepartureTrains.Count);
        }

        [Test]
        public void Test_TrainHasLeft()
        {
            RailwayStation railwayStation = new RailwayStation(name);

            railwayStation.NewArrivalOnBoard(trainInfo);

            railwayStation.TrainHasArrived(trainInfo);

            Assert.IsFalse(railwayStation.TrainHasLeft(trainInfo + "1"));
            Assert.AreEqual(1,railwayStation.DepartureTrains.Count);

            Assert.IsTrue(railwayStation.TrainHasLeft(trainInfo));
            Assert.AreEqual(0, railwayStation.DepartureTrains.Count);
        }
    }
}