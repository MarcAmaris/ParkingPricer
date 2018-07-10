using Autofac;
using NUnit.Framework;
using ParkingPricer;

namespace ParkingPricerTests.BddTests.Given_ShortDurationParkingPricerManager
{
    [TestFixture]
    public class When_GetPrice
    {
        private ContainerBuilder _builder;
        private IContainer _container;
        private ILifetimeScope _scope;

        [SetUp]
        public void SetUp()
        {
            _builder = new ContainerBuilder();
            _builder.RegisterType<ShortDurationParkingPricerManager>().As<IParkingPricerManager>();
            _container = _builder.Build();
            _scope = _container.BeginLifetimeScope();
        }

        [TearDown]
        public void TearDown()
        {
            _scope.Dispose();
            _container.Dispose();
        }

        [Test]
        public void WithDurationNotANumber_Should_Throw_ArgumentException()
        {            
            var parkingPricerManager = _scope.Resolve<IParkingPricerManager>();  
            string duration = "a";

            Assert.That(() => parkingPricerManager.GetPrice(duration), Throws.ArgumentException);
        }

        [Test]
        public void WithDurationLessThan0_Should_Throw_ArgumentException()
        {
            var parkingPricerManager = _scope.Resolve<IParkingPricerManager>();
            string duration = "-1";

            Assert.That(() => parkingPricerManager.GetPrice(duration), Throws.ArgumentException);
        }

        [Test]
        public void WithDurationNull_Should_Throw_ArgumentException()
        {
            var parkingPricerManager = _scope.Resolve<IParkingPricerManager>();
            string duration = null;

            Assert.That(() => parkingPricerManager.GetPrice(duration), Throws.ArgumentException);
        }

        [Test]
        public void WithDuration0_Should_Get_0()
        {
            var parkingPricerManager = _scope.Resolve<IParkingPricerManager>();
            string duration = "0.0";
            int expected = 0;

            int result = parkingPricerManager.GetPrice(duration);
            Assert.AreEqual(expected, result, "Price must be 0");
        }

        [Test]
        public void WithDuration1_Should_Get_18()
        {
            var parkingPricerManager = _scope.Resolve<IParkingPricerManager>();
            string duration = "1";
            int expected = 18;

            int result = parkingPricerManager.GetPrice(duration);
            Assert.AreEqual(expected, result, "Price must be 18");
        }

        [Test]
        public void WithDuration12_Should_Get_37()
        {
            var parkingPricerManager = _scope.Resolve<IParkingPricerManager>();
            string duration = "12";
            int expected = 37;

            int result = parkingPricerManager.GetPrice(duration);
            Assert.AreEqual(expected, result, "Price must be 37");
        }

        [Test]
        public void WithDuration25dot5_Should_Get_67()
        {
            var parkingPricerManager = _scope.Resolve<IParkingPricerManager>();
            string duration = "25.5";
            int expected = 67;

            int result = parkingPricerManager.GetPrice(duration);
            Assert.AreEqual(expected, result, "Price must be 67");
        }
    }
}