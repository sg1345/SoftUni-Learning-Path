namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Reflection;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void Test_Constructor()
        {
            string make = "name";
            string model = "model";
            double fuelConsumption = 1;
            double fuelCapacity = 1;
            Car car = new(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(0, car.FuelAmount);
            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
        }

        [TestCase(null, "Test", 1, 1), TestCase("", "Test", 1, 1),
         TestCase("Test", null, 1, 1), TestCase("Test", "", 1, 1),
         TestCase("Test", "Test", 0, 1), TestCase("Test", "Test", -1, 1),
         TestCase("Test", "Test", 1, 0), TestCase("Test", "Test", 1, -1)]
        public void Test_Constructor_PropertiesSettersArgumentException
            (string make, string model, double fuelConsumption, double fuelCapacity)
        {

            //Car car = new(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [TestCase("Test", "Test", 1, 10, 1), TestCase("Test", "Test", 1, 10, 9)]
        public void Test_Refuel_WorksWhenFuelAmountLessThanMaximumCapacity
            (string make, string model, double fuelConsumption, double fuelCapacity, double refueledAmount)
        {
            Car car = new(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(refueledAmount);

            Assert.AreEqual(refueledAmount, car.FuelAmount);
        }

        [TestCase("Test", "Test", 1, 10, 10)]
        public void Test_Refuel_WorksWhenFuelAmountEqualsMaximumCapacity
            (string make, string model, double fuelConsumption, double fuelCapacity, double refueledAmount)
        {
            Car car = new(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(refueledAmount);

            Assert.AreEqual(refueledAmount, car.FuelAmount);
        }

        [TestCase("Test", "Test", 1, 10, 11)]
        public void Test_Refuel_WorksWhenFuelAmountExceedsMaximumCapacity
            (string make, string model, double fuelConsumption, double fuelCapacity, double refueledAmount)
        {
            Car car = new(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(refueledAmount);

            Assert.AreEqual(car.FuelCapacity, car.FuelAmount);
        }

        [TestCase(-1), TestCase(0)]
        public void Test_Refuel_fuelToRefuelIsNegativeOrZero_ArgumentException(double fuel)
        {
            Car car = new("Test", "Test", 1, 10);

            Assert.Throws<ArgumentException>(() => car.Refuel(fuel));
        }

        [Test]
        public void Test_Drive()
        {
            Car car = new("Test", "Test", 1, 10);

            car.Refuel(car.FuelCapacity);
            car.Drive(100);

            Assert.AreEqual(car.FuelCapacity - car.FuelConsumption, car.FuelAmount);
        }

        [Test]
        public void Test_Drive_fuelNeededMoreThanFuelAmount_InvalidOperationException()
        {
            Car car = new("Test", "Test", 1, 10);

            car.Refuel(car.FuelCapacity);

            Assert.Throws<InvalidOperationException>(() => car.Drive(10000));
        }

        [Test]
        public void Test_FuelAmount_Setter_ArgumentException()
        {
            Car car = new Car("Test", "Test", 1, 10);

            Type type = typeof(Car);
            PropertyInfo property = type.GetProperty("FuelAmount", BindingFlags.Instance | BindingFlags.Public);
            //MethodInfo setter = property.GetGetMethod(true);
            ;

            var exception = Assert.Throws<TargetInvocationException>(() => property.SetValue(car, -1));

            Assert.That(exception.InnerException, Is.TypeOf<ArgumentException>());
        }
    }
}