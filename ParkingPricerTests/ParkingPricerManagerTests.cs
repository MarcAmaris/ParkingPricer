using NUnit.Framework;

namespace ParkingPricer.Tests
{
    [TestFixture]
    public class ParkingPricerManagerTests
    {
        #region GetPrice
        [Test]
        public void GetPrice_DurationNotAsInt_ExpectArgumentException()
        {
            string flatRate = ParkingFlatRate.Floor.ToString();            
            var parkingPricerManager = ParkingPricerFactory.Create(flatRate);
            string duration = "a";

            Assert.That(() => parkingPricerManager.GetPrice(duration), Throws.ArgumentException);
        }

        [Test]
        public void GetPrice_DurationLessThan0_ExpectArgumentException()
        {
            string flatRate = ParkingFlatRate.Floor.ToString();            
            var parkingPricerManager = ParkingPricerFactory.Create(flatRate);
            string duration = "-1";

            Assert.That(() => parkingPricerManager.GetPrice(duration), Throws.ArgumentException);
        }

        [Test]
        public void GetPrice_DurationAsNull_ExpectArgumentException()
        {
            string flatRate = ParkingFlatRate.Floor.ToString();            
            var parkingPricerManager = ParkingPricerFactory.Create(flatRate);
            string duration = null;

            Assert.That(() => parkingPricerManager.GetPrice(duration), Throws.ArgumentException);
        }

        [Test]
        public void GetPrice_FlatRateAsShortDurationAndDurationAs0_Expect0()
        {
            string flatRate = ParkingFlatRate.ShortDuration.ToString();            
            var parkingPricerManager = ParkingPricerFactory.Create(flatRate);
            string duration = "0.0";
            int expected = 0;

            int result = parkingPricerManager.GetPrice(duration);
            Assert.AreEqual(expected, result, "Price must be 0");
        }

        [Test]
        public void GetPrice_FlatRateAsShortDurationAndDurationAs1_Expect18()
        {
            string flatRate = ParkingFlatRate.ShortDuration.ToString();            
            var parkingPricerManager = ParkingPricerFactory.Create(flatRate);
            string duration = "1";
            int expected = 18;

            int result = parkingPricerManager.GetPrice(duration);
            Assert.AreEqual(expected, result, "Price must be 18");
        }

        [Test]
        public void GetPrice_FlatRateAsShortDurationAndDurationAs12_Expect37()
        {
            string flatRate = ParkingFlatRate.ShortDuration.ToString();            
            var parkingPricerManager = ParkingPricerFactory.Create(flatRate);
            string duration = "12";
            int expected = 37;

            int result = parkingPricerManager.GetPrice(duration);
            Assert.AreEqual(expected, result, "Price must be 37");
        }

        [Test]
        public void GetPrice_FlatRateAsFloorAndDurationAs25dot5_Expect60()
        {
            string flatRate = ParkingFlatRate.Floor.ToString();            
            var parkingPricerManager = ParkingPricerFactory.Create(flatRate);
            string duration = "25.5";
            int expected = 60;

            int result = parkingPricerManager.GetPrice(duration);
            Assert.AreEqual(expected, result, "Price must be 60");
        }
        #endregion

        #region PricePerFlatRate
        [Test]
        public void PricePerFlatRate_FlatRateAsShortDuration_Expect6()
        {
            string flatRate = ParkingFlatRate.ShortDuration.ToString();            
            var parkingPricerManager = ParkingPricerFactory.Create(flatRate);
            int expected = 6;

            int result = parkingPricerManager.PricePerFlatRate;
            Assert.AreEqual(expected, result, "Price per FlatRate must be 6");
        }

        [Test]
        public void PricePerFlatRate_FlatRateAsFloor_Expect6()
        {
            string flatRate = ParkingFlatRate.Floor.ToString();            
            var parkingPricerManager = ParkingPricerFactory.Create(flatRate);
            int expected = 6;

            int result = parkingPricerManager.PricePerFlatRate;
            Assert.AreEqual(expected, result, "Price per FlatRate must be 6");
        }

        [Test]
        public void PricePerFlatRate_FlatRateAsValetParc_Expect12()
        {
            string flatRate = ParkingFlatRate.ValetParc.ToString();            
            var parkingPricerManager = ParkingPricerFactory.Create(flatRate);
            int expected = 12;

            int result = parkingPricerManager.PricePerFlatRate;
            Assert.AreEqual(expected, result, "Price per FlatRate must be 12");
        }
        #endregion

        #region DayPriceLimit
        [Test]
        public void DayPriceLimit_FlatRateAsShortDuration_Expect37()
        {
            string flatRate = ParkingFlatRate.ShortDuration.ToString();            
            var parkingPricerManager = ParkingPricerFactory.Create(flatRate);
            int expected = 37;

            int result = parkingPricerManager.DayPriceLimit;
            Assert.AreEqual(expected, result, "Day price limit must be 37");
        }

        [Test]
        public void DayPriceLimit_FlatRateAsFloor_Expect30()
        {
            string flatRate = ParkingFlatRate.Floor.ToString();            
            var parkingPricerManager = ParkingPricerFactory.Create(flatRate);
            int expected = 30;

            int result = parkingPricerManager.DayPriceLimit;
            Assert.AreEqual(expected, result, "Day price limit must be 30");
        }

        [Test]
        public void DayPriceLimit_FlatRateAsValetParc_Expect42()
        {
            string flatRate = ParkingFlatRate.ValetParc.ToString();            
            var parkingPricerManager = ParkingPricerFactory.Create(flatRate);
            int expected = 42;

            int result = parkingPricerManager.DayPriceLimit;
            Assert.AreEqual(expected, result, "Day price limit must be 42");
        }
        #endregion
    }
}