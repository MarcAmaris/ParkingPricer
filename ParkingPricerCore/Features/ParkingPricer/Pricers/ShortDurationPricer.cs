
using ParkingPricerCore.Managers;

namespace ParkingPricerCore.Features.ParkingPricer.Pricers
{
    public class ShortDurationPricer : IParkingPriceStrategy
    {
        private readonly IPriceCalculator _calculator;
        private readonly IDurationFormatter _formatter;

        private const int DayPriceLimit = 37;
        private const int PricePerFlateRate = 6;

        public ShortDurationPricer(IPriceCalculator calculator, IDurationFormatter formatter)
        {
            _calculator = calculator;
            _formatter = formatter;
        }

        public int GetPrice(string duration)
        {
            var result = _formatter.Format(duration);
            return _calculator.CalculatePrice(result, DayPriceLimit, PricePerFlateRate);
        }

        public ParkingFlatRate Rate => ParkingFlatRate.ShortDuration;
    }
}
