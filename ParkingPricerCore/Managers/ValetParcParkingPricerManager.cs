namespace ParkingPricer
{
    public sealed class ValetParcParkingPricerManager : ParkingPricerManager
    {
        public override int DayPriceLimit => Consts.ValetParcLimitPrice;

        public override int PricePerFlatRate => Consts.ValetParcPrice;
    }
}