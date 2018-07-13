namespace ParkingPricerCore.Managers
{
    public interface IParkingPricerManager
    {
        int DayPriceLimit { get; }
        int PricePerFlatRate { get; }
        int GetPrice(string durationStr);
    }
}