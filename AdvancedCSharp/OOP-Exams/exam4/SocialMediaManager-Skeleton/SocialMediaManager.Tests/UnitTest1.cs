using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace SocialMediaManager.Tests
{
    public class Tests
    {
        private const string username = "TestName";
        private const int followers = 1;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_Constructor()
        {
            InfluencerRepository repository = new InfluencerRepository();

            Assert.AreEqual(0, repository.Influencers.Count);
        }

        [Test]
        public void Test_RegisterInfluencer_IsNull_ArgumentNullException()
        {
            InfluencerRepository repository = new InfluencerRepository();

            Influencer influencer = null;

            Assert.Throws<ArgumentNullException>(() => repository.RegisterInfluencer(influencer));
        }

        [Test]
        public void Test_RegisterInfluencer_Exist_InvalidOperationException()
        {
            InfluencerRepository repository = new InfluencerRepository();

            Influencer influencer = new Influencer(username, followers);
            repository.RegisterInfluencer(influencer);

            Assert.Throws<InvalidOperationException>(() => repository.RegisterInfluencer(influencer));
        }

        [Test]
        public void Test_RegisterInfluencer()
        {
            InfluencerRepository repository = new InfluencerRepository();

            Influencer influencer = new Influencer(username, followers);

            Assert.AreEqual($"Successfully added influencer {influencer.Username} with {influencer.Followers}", repository.RegisterInfluencer(influencer));
            Assert.AreEqual(1, repository.Influencers.Count);
        }
        [TestCase(null), TestCase(" ")]
        public void Test_RemoveInfluencer_InputIsNullOrWhiteSpace_ArgumentNullException(string notValidUsername)
        {
            InfluencerRepository repository = new InfluencerRepository();
            Influencer influencer = new Influencer(username, followers);

            repository.RegisterInfluencer(influencer);
            Assert.Throws<ArgumentNullException>(() => repository.RemoveInfluencer(notValidUsername));
            Assert.AreEqual(1, repository.Influencers.Count);
        }

        [Test]
        public void Test_RemoveInfluencer_IsTrue()
        {
            InfluencerRepository repository = new InfluencerRepository();
            Influencer influencer = new Influencer(username, followers);

            repository.RegisterInfluencer(influencer);
            Assert.IsTrue(repository.RemoveInfluencer(username));
            Assert.AreEqual(0, repository.Influencers.Count);
        }

        [Test]
        public void Test_RemoveInfluencer_IsFalse()
        {
            InfluencerRepository repository = new InfluencerRepository();
            Influencer influencer = new Influencer(username, followers);

            repository.RegisterInfluencer(influencer);
            Assert.IsFalse(repository.RemoveInfluencer(username + "1"));
            Assert.AreEqual(1, repository.Influencers.Count);
        }

        [Test]
        public void GetInfluencerWithMostFollowers()
        {
            InfluencerRepository repository = new InfluencerRepository();
            Influencer influencer = new Influencer(username, followers);
            Influencer influencerBigger = new Influencer(username+"1", followers+1);

            repository.RegisterInfluencer(influencer);
            repository.RegisterInfluencer(influencerBigger);

            Influencer biggestInfluencer = repository.GetInfluencerWithMostFollowers();

            Assert.AreEqual(influencerBigger.Username, biggestInfluencer.Username);
            Assert.AreEqual(influencerBigger.Followers, biggestInfluencer.Followers);
        }

        [Test]
        public void GetInfluencerWithMostFollowers_NullCaseMaybe()
        {
            InfluencerRepository repository = new InfluencerRepository();

            Assert.Throws<IndexOutOfRangeException>(()=> repository.GetInfluencerWithMostFollowers());           
        }

        [Test]
        public void GetInfluencer()
        {
            InfluencerRepository repository = new InfluencerRepository();
            Influencer influencer = new Influencer(username, followers);
            Influencer otherInfluencer = new Influencer(username + "1", followers);

            repository.RegisterInfluencer(influencer);
            repository.RegisterInfluencer(otherInfluencer);

            Influencer currentInfluencer =  repository.GetInfluencer(username);

            Assert.AreEqual(influencer.Username, currentInfluencer.Username);
            Assert.AreEqual(influencer.Followers, currentInfluencer.Followers);
        }

        [Test]
        public void GetInfluencer_Null()
        {
            InfluencerRepository repository = new InfluencerRepository();
            Influencer influencer = new Influencer(username, followers);
            Influencer otherInfluencer = new Influencer(username + "1", followers);

            repository.RegisterInfluencer(influencer);
            repository.RegisterInfluencer(otherInfluencer);

            Assert.AreEqual(null, repository.GetInfluencer(username+"2"));

        }
    }
}