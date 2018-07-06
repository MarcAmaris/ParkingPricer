using NUnit.Framework;

namespace ParkingPricer.Tests
{
    [TestFixture]
    public class ParkingPricerManagerTests
    {
        [Test]
        public void GetActualPrice_FlatRateAsValueNotInEnum_ExpectArgumentException()
        {
            var parkingPricerManager = new ParkingPricerManager();
            string flatRate = "none";
            string duration = "0";

            Assert.That(() => parkingPricerManager.GetActualPrice(flatRate, duration), Throws.ArgumentException);
        }

        [Test]
        public void GetActualPrice_FlatRateAsNull_ExpectArgumentException()
        {
            var parkingPricerManager = new ParkingPricerManager();
            string flatRate = null;
            string duration = "0";

            Assert.That(() => parkingPricerManager.GetActualPrice(flatRate, duration), Throws.ArgumentException);
        }

        [Test]
        public void GetActualPrice_DurationNotAsInt_ExpectArgumentException()
        {
            var parkingPricerManager = new ParkingPricerManager();
            string flatRate = ParkingFlatRate.Floor.ToString();
            string duration = "a";

            Assert.That(() => parkingPricerManager.GetActualPrice(flatRate, duration), Throws.ArgumentException);
        }

        [Test]
        public void GetActualPrice_DurationAsNull_ExpectArgumentException()
        {
            var parkingPricerManager = new ParkingPricerManager();
            string flatRate = ParkingFlatRate.Floor.ToString();
            string duration = null;

            Assert.That(() => parkingPricerManager.GetActualPrice(flatRate, duration), Throws.ArgumentException);
        }
    }
}