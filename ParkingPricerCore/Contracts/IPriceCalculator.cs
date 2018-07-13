namespace ParkingPricerCore.Features
{
    public interface IPriceCalculator
    {
        int CalculatePrice(decimal duration, int dayPriceLimit, int pricePerFlateRate);
    }
}
