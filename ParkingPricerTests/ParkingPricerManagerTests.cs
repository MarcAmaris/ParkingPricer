using NUnit.Framework;

namespace ParkingPricer.Tests
{
    [TestFixture]
    public class ParkingPricerManagerTests
    {
        #region GetPrice
        [Test]
        public void GetPrice_FlatRateAsValueNotInEnum_ExpectArgumentException()
        {
            var parkingPricerManager = new ParkingPricerManager();
            string flatRate = "none";
            string duration = "0";

            Assert.That(() => parkingPricerManager.GetPrice(flatRate, duration), Throws.ArgumentException);
        }

        [Test]
        public void GetPrice_FlatRateAsNull_ExpectArgumentException()
        {
            var parkingPricerManager = new ParkingPricerManager();
            string flatRate = null;
            string duration = "0";

            Assert.That(() => parkingPricerManager.GetPrice(flatRate, duration), Throws.ArgumentException);
        }

        [Test]
        public void GetPrice_DurationNotAsInt_ExpectArgumentException()
        {
            var parkingPricerManager = new ParkingPricerManager();
            string flatRate = ParkingFlatRate.Floor.ToString();
            string duration = "a";

            Assert.That(() => parkingPricerManager.GetPrice(flatRate, duration), Throws.ArgumentException);
        }

        [Test]
        public void GetPrice_DurationLessThan0_ExpectArgumentException()
        {
            var parkingPricerManager = new ParkingPricerManager();
            string flatRate = ParkingFlatRate.Floor.ToString();
            string duration = "-1";

            Assert.That(() => parkingPricerManager.GetPrice(flatRate, duration), Throws.ArgumentException);
        }

        [Test]
        public void GetPrice_DurationAsNull_ExpectArgumentException()
        {
            var parkingPricerManager = new ParkingPricerManager();
            string flatRate = ParkingFlatRate.Floor.ToString();
            string duration = null;

            Assert.That(() => parkingPricerManager.GetPrice(flatRate, duration), Throws.ArgumentException);
        }

        [Test]
        public void GetPrice_FlatRateAsShortDurationAndDurationAs0_Expect0()
        {
            var parkingPricerManager = new ParkingPricerManager();
            string flatRate = ParkingFlatRate.ShortDuration.ToString();
            string duration = "0.0";
            int expected = 0;

            int result = parkingPricerManager.GetPrice(flatRate, duration);
            Assert.AreEqual(expected, result, "Price must be 0");
        }

        [Test]
        public void GetPrice_FlatRateAsShortDurationAndDurationAs1_Expect18()
        {
            var parkingPricerManager = new ParkingPricerManager();
            string flatRate = ParkingFlatRate.ShortDuration.ToString();
            string duration = "1";
            int expected = 18;

            int result = parkingPricerManager.GetPrice(flatRate, duration);
            Assert.AreEqual(expected, result, "Price must be 18");
        }

        [Test]
        public void GetPrice_FlatRateAsShortDurationAndDurationAs12_Expect37()
        {
            var parkingPricerManager = new ParkingPricerManager();
            string flatRate = ParkingFlatRate.ShortDuration.ToString();
            string duration = "12";
            int expected = 37;

            int result = parkingPricerManager.GetPrice(flatRate, duration);
            Assert.AreEqual(expected, result, "Price must be 37");
        }

        [Test]
        public void GetPrice_FlatRateAsFloorAndDurationAs25dot5_Expect60()
        {
            var parkingPricerManager = new ParkingPricerManager();
            string flatRate = ParkingFlatRate.Floor.ToString();
            string duration = "25.5";
            int expected = 60;

            int result = parkingPricerManager.GetPrice(flatRate, duration);
            Assert.AreEqual(expected, result, "Price must be 60");
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

        #region GetDayPriceLimit
        [Test]
        public void GetDayPriceLimit_FlatRateAsShortDuration_Expect37()
        {
            var parkingPricerManager = new ParkingPricerManager();
            var flatRate = ParkingFlatRate.ShortDuration;
            int expected = 37;

            int result = parkingPricerManager.GetDayPriceLimit(flatRate);
            Assert.AreEqual(expected, result, "Day price limit must be 37");
        }

        [Test]
        public void GetDayPriceLimit_FlatRateAsFloor_Expect30()
        {
            var parkingPricerManager = new ParkingPricerManager();
            var flatRate = ParkingFlatRate.Floor;
            int expected = 30;

            int result = parkingPricerManager.GetDayPriceLimit(flatRate);
            Assert.AreEqual(expected, result, "Day price limit must be 30");
        }

        [Test]
        public void GetDayPriceLimit_FlatRateAsValetParc_Expect42()
        {
            var parkingPricerManager = new ParkingPricerManager();
            var flatRate = ParkingFlatRate.ValetParc;
            int expected = 42;

            int result = parkingPricerManager.GetDayPriceLimit(flatRate);
            Assert.AreEqual(expected, result, "Day price limit must be 42");
        }
        #endregion
    }
}