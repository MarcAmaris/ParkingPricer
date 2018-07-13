
using ParkingPricerCore.Managers;

namespace ParkingPricerCore.Features.ParkingPricer.Pricers
{
    public interface IParkingPriceStrategy
    {
        int GetPrice(string duration);
        ParkingFlatRate Rate { get; }
    }
}
