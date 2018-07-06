using NUnit.Framework;

namespace ParkingPricer.Tests
{
    [TestFixture]
    public class ParkingPricerManagerTests
    {
        [Test]
        public void ShowActualPrice_flatRateAsValueNotInEnum_ExpectArgumentException()
        {
            var parkingPricerManager = new ParkingPricerManager();
            string flatRate = "none";
            string duration = "0";

            Assert.That(() => parkingPricerManager.ShowActualPrice(flatRate, duration), Throws.ArgumentException);
        }

        [Test]
        public void ShowActualPrice_flatRateAsNull_ExpectArgumentException()
        {
            var parkingPricerManager = new ParkingPricerManager();
            string flatRate = null;
            string duration = "0";

            Assert.That(() => parkingPricerManager.ShowActualPrice(flatRate, duration), Throws.ArgumentException);
        }

        [Test]
        public void ShowActualPrice_durationNotAsInt_ExpectArgumentException()
        {
            var parkingPricerManager = new ParkingPricerManager();
            string flatRate = ParkingFlatRate.Floor.ToString();
            string duration = "a";

            Assert.That(() => parkingPricerManager.ShowActualPrice(flatRate, duration), Throws.ArgumentException);
        }

        [Test]
        public void ShowActualPrice_durationAsNull_ExpectArgumentException()
        {
            var parkingPricerManager = new ParkingPricerManager();
            string flatRate = ParkingFlatRate.Floor.ToString();
            string duration = null;

            Assert.That(() => parkingPricerManager.ShowActualPrice(flatRate, duration), Throws.ArgumentException);
        }
    }
}