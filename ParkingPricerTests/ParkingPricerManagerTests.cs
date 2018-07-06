using NUnit.Framework;

namespace ParkingPricer.Tests
{
    [TestFixture]
    public class ParkingPricerManagerTests
    {
        #region GetActualPrice
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
        public void GetActualPrice_DurationLessThan0_ExpectArgumentException()
        {
            var parkingPricerManager = new ParkingPricerManager();
            string flatRate = ParkingFlatRate.Floor.ToString();
            string duration = "-1";

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

        [Test]
        public void GetActualPrice_FlatRateAsShortDurationAndDurationAs21_Expect12()
        {
            var parkingPricerManager = new ParkingPricerManager();
            string flatRate = ParkingFlatRate.ShortDuration.ToString();
            string duration = "21";
            int expected = 12;

            int result = parkingPricerManager.GetActualPrice(flatRate, duration);
            Assert.AreEqual(expected, result, "Actual price must be 12");
        }

        [Test]
        public void GetActualPrice_FlatRateAsFloorAndDurationAs120_Expect30()
        {
            var parkingPricerManager = new ParkingPricerManager();
            string flatRate = ParkingFlatRate.Floor.ToString();
            string duration = "120";
            int expected = 30;

            int result = parkingPricerManager.GetActualPrice(flatRate, duration);
            Assert.AreEqual(expected, result, "Actual price must be 30");
        }

        [Test]
        public void GetActualPrice_FlatRateAsValetParcAndDurationAs120_Expect42()
        {
            var parkingPricerManager = new ParkingPricerManager();
            string flatRate = ParkingFlatRate.ValetParc.ToString();
            string duration = "120";
            int expected = 42;

            int result = parkingPricerManager.GetActualPrice(flatRate, duration);
            Assert.AreEqual(expected, result, "Actual price must be 42");
        }
        #endregion

        #region GetPricePerFlatRate
        [Test]
        public void GetPricePerFlatRate_FlatRateAsShortDuration_Expect6()
        {
            var parkingPricerManager = new ParkingPricerManager();
            var flatRate = ParkingFlatRate.ShortDuration;
            int expected = 6;

            int result = parkingPricerManager.GetPricePerFlatRate(flatRate);
            Assert.AreEqual(expected, result, "Price per FlatRate must be 6");
        }

        [Test]
        public void GetPricePerFlatRate_FlatRateAsFloor_Expect6()
        {
            var parkingPricerManager = new ParkingPricerManager();
            var flatRate = ParkingFlatRate.Floor;
            int expected = 6;

            int result = parkingPricerManager.GetPricePerFlatRate(flatRate);
            Assert.AreEqual(expected, result, "Price per FlatRate must be 6");
        }

        [Test]
        public void GetPricePerFlatRate_FlatRateAsValetParc_Expect12()
        {
            var parkingPricerManager = new ParkingPricerManager();
            var flatRate = ParkingFlatRate.ValetParc;
            int expected = 12;

            int result = parkingPricerManager.GetPricePerFlatRate(flatRate);
            Assert.AreEqual(expected, result, "Price per FlatRate must be 12");
        }
        #endregion

        #region GetRealPrice
        [Test]
        public void GetRealPrice_FlatRateAsShortDurationAndTheoricalPriceAs50_Expect37()
        {
            var parkingPricerManager = new ParkingPricerManager();
            var flatRate = ParkingFlatRate.ShortDuration;
            int theoricalPrice = 50;
            int expected = 37;

            int result = parkingPricerManager.GetRealPrice(flatRate, theoricalPrice);
            Assert.AreEqual(expected, result, "Real Price must be 37");
        }

        [Test]
        public void GetRealPrice_FlatRateAsShortDurationAndTheoricalPriceAs15_Expect15()
        {
            var parkingPricerManager = new ParkingPricerManager();
            var flatRate = ParkingFlatRate.ShortDuration;
            int theoricalPrice = 15;
            int expected = 15;

            int result = parkingPricerManager.GetRealPrice(flatRate, theoricalPrice);
            Assert.AreEqual(expected, result, "Real Price must be 15");
        }

        [Test]
        public void GetRealPrice_FlatRateAsFloorAndTheoricalPriceAs50_Expect30()
        {
            var parkingPricerManager = new ParkingPricerManager();
            var flatRate = ParkingFlatRate.Floor;
            int theoricalPrice = 50;
            int expected = 30;

            int result = parkingPricerManager.GetRealPrice(flatRate, theoricalPrice);
            Assert.AreEqual(expected, result, "Real Price must be 30");
        }

        [Test]
        public void GetRealPrice_FlatRateAsFloorAndTheoricalPriceAs15_Expect15()
        {
            var parkingPricerManager = new ParkingPricerManager();
            var flatRate = ParkingFlatRate.Floor;
            int theoricalPrice = 15;
            int expected = 15;

            int result = parkingPricerManager.GetRealPrice(flatRate, theoricalPrice);
            Assert.AreEqual(expected, result, "Real Price must be 15");
        }

        [Test]
        public void GetRealPrice_FlatRateAsValetParcAndTheoricalPriceAs50_Expect42()
        {
            var parkingPricerManager = new ParkingPricerManager();
            var flatRate = ParkingFlatRate.ValetParc;
            int theoricalPrice = 50;
            int expected = 42;

            int result = parkingPricerManager.GetRealPrice(flatRate, theoricalPrice);
            Assert.AreEqual(expected, result, "Real Price must be 42");
        }

        [Test]
        public void GetRealPrice_FlatRateAsValetParcAndTheoricalPriceAs15_Expect15()
        {
            var parkingPricerManager = new ParkingPricerManager();
            var flatRate = ParkingFlatRate.ValetParc;
            int theoricalPrice = 15;
            int expected = 15;

            int result = parkingPricerManager.GetRealPrice(flatRate, theoricalPrice);
            Assert.AreEqual(expected, result, "Real Price must be 15");
        }
        #endregion
    }
}