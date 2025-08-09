namespace Television.Tests
{
    using System;
    using System.Diagnostics;
    using NUnit.Framework;
    public class Tests
    {
        private const string brand = "testBrand";
        private const double price = 1.1;
        private const int screenWidth = 2;
        private const int screenHeigth = 1;


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_Constructor()
        {
            TelevisionDevice televisionDevice = new TelevisionDevice(brand, price, screenWidth, screenHeigth);

            Assert.AreEqual(brand, televisionDevice.Brand);
            Assert.AreEqual(price, televisionDevice.Price);
            Assert.AreEqual(screenWidth, televisionDevice.ScreenWidth);
            Assert.AreEqual(screenHeigth, televisionDevice.ScreenHeigth);

            Assert.AreEqual(0, televisionDevice.CurrentChannel);
            Assert.AreEqual(13, televisionDevice.Volume);
            Assert.AreEqual(false, televisionDevice.IsMuted);
        }

        [Test]
        public void Test_SwitchOn()
        {
            TelevisionDevice televisionDevice = new TelevisionDevice(brand, price, screenWidth, screenHeigth);

            string sound = televisionDevice.IsMuted ? "Off" : "On";

            Assert.AreEqual($"Cahnnel {televisionDevice.CurrentChannel} - Volume {televisionDevice.Volume} - Sound {sound}", televisionDevice.SwitchOn());
        }

        [Test]
        public void Test_ChangeChannel_InvalidKey_ArgumentException()
        {
            TelevisionDevice televisionDevice = new TelevisionDevice(brand, price, screenWidth, screenHeigth);

            Assert.Throws<ArgumentException>(() => televisionDevice.ChangeChannel(-1));
        }

        [TestCase(0), TestCase(1), TestCase(50), TestCase(99)]
        public void Test_ChangeChannel(int channel)
        {
            TelevisionDevice televisionDevice = new TelevisionDevice(brand, price, screenWidth, screenHeigth);

            Assert.AreEqual(channel, televisionDevice.ChangeChannel(channel));
            Assert.AreEqual(channel, televisionDevice.CurrentChannel);
        }

        [TestCase("UP", -1), TestCase("UP", 1), TestCase("UP", 100), TestCase("UP", -100), TestCase("UP", 50), TestCase("UP", -50)]
        [TestCase("DOWN", -1), TestCase("DOWN", 1), TestCase("DOWN", 100), TestCase("DOWN", -100), TestCase("DOWN", 50), TestCase("DOWN", -50)]
        public void Test_VolumeChange(string direction, int units)
        {
            TelevisionDevice televisionDevice = new TelevisionDevice(brand, price, screenWidth, screenHeigth);

            int expectedVolume = 13;
            if (direction == "UP")
            {
                expectedVolume += Math.Abs(units);
                if (expectedVolume > 100)
                {
                    expectedVolume = 100;
                }
            }
            else if (direction == "DOWN")
            {
                expectedVolume -= Math.Abs(units);
                if (expectedVolume < 0)
                {
                    expectedVolume = 0;
                }
            }

            Assert.AreEqual($"Volume: {expectedVolume}", televisionDevice.VolumeChange(direction,units));
            Assert.AreEqual(expectedVolume, televisionDevice.Volume);
        }

        [Test]
        public void Test_MuteDevice()
        {
            TelevisionDevice televisionDevice = new TelevisionDevice(brand, price, screenWidth, screenHeigth);

            Assert.IsTrue(televisionDevice.MuteDevice());
            Assert.IsTrue(televisionDevice.IsMuted);

            Assert.IsFalse(televisionDevice.MuteDevice());
            Assert.IsFalse(televisionDevice.IsMuted);
        }

        [Test]
        public void Test_ToString()
        {
            TelevisionDevice televisionDevice = new TelevisionDevice(brand, price, screenWidth, screenHeigth);

            Assert.AreEqual($"TV Device: {brand}, Screen Resolution: {screenWidth}x{screenHeigth}, Price {price}$",televisionDevice.ToString());
        }
    }
}