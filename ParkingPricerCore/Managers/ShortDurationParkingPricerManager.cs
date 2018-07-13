namespace ParkingPricerCore.Managers
{
    public sealed class ShortDurationParkingPricerManager : ParkingPricerManager
    {
        public override int DayPriceLimit => Consts.ShortDurationLimitPrice;

        public override int PricePerFlatRate => Consts.ShortDurationAndFloorPrice;
    }
}