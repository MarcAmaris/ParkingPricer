namespace ParkingPricerCore.Managers
{
    public sealed class FloorParkingPricerManager : ParkingPricerManager
    {
        public override int DayPriceLimit => Consts.FloorLimitPrice;

        public override int PricePerFlatRate => Consts.ShortDurationAndFloorPrice;
    }
}