using NUnit.Framework;
using ParkingPricer;

namespace ParkingPricer.Tests.Bdd
{
    [TestFixture]
    public class ParkingPricerFactoryTests
    {
        #region Create
        [Test]
        public void Create_FlatRateAsValueNotInEnum_ExpectArgumentException()
        {
            string flatRate = "none";

            Assert.That(() => ParkingPricerFactory.Create(flatRate), Throws.ArgumentException);
        }

        [Test]
        public void Create_FlatRateAsNull_ExpectArgumentException()
        {
            string flatRate = null;

            Assert.That(() => ParkingPricerFactory.Create(flatRate), Throws.ArgumentException);
        }

        [Test]
        public void Create_FlatRateAsShortDuration_ExpectShortDurationParkingPricerManager()
        {
            string flatRate = ParkingFlatRate.ShortDuration.ToString();
            var parkingpricerManager = ParkingPricerFactory.Create(flatRate);

            Assert.IsInstanceOf(typeof(ShortDurationParkingPricerManager), parkingpricerManager
                , "Manager should be instance of ShortDurationParkingPricerManager");
        }

        [Test]
        public void Create_FlatRateAsFloor_ExpectFloorParkingPricerManager()
        {
            string flatRate = ParkingFlatRate.Floor.ToString();
            var parkingpricerManager = ParkingPricerFactory.Create(flatRate);

            Assert.IsInstanceOf(typeof(FloorParkingPricerManager), parkingpricerManager
                , "Manager should be instance of FloorParkingPricerManager");
        }

        [Test]
        public void Create_FlatRateAsValetParc_ExpectValetParcPricerManager()
        {
            string flatRate = ParkingFlatRate.ValetParc.ToString();
            var parkingpricerManager = ParkingPricerFactory.Create(flatRate);

            Assert.IsInstanceOf(typeof(ValetParcParkingPricerManager), parkingpricerManager
                , "Manager should be instance of ValetParcParkingPricerManager");
        }
        #endregion
    }
}