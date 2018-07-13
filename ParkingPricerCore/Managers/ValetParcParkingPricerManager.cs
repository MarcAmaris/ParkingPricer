namespace ParkingPricerCore.Managers
{
    public sealed class ValetParcParkingPricerManager : ParkingPricerManager
    {
        public override int DayPriceLimit => Consts.ValetParcLimitPrice;

        public override int PricePerFlatRate => Consts.ValetParcPrice;
    }
}