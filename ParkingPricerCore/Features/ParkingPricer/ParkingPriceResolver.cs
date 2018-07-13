using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ParkingPricerCore.Features;
using ParkingPricerCore.Features.ParkingPricer.Pricers;
using ParkingPricerCore.Managers;

namespace ParkingPricerCore.Resolvers
{
    public class ParkingPriceResolver : IParkingPriceResolver
    {
        private readonly IParkingPriceStrategy[] _strategies;

        public ParkingPriceResolver(IParkingPriceStrategy[] strategies)
        {
            _strategies = strategies;
        }

        public IParkingPriceStrategy Resolve(ParkingFlatRate flatRate)
        {
            return _strategies.FirstOrDefault(x => x.Rate == flatRate);
        }
    }

    public interface IParkingPriceResolver
    {
        IParkingPriceStrategy Resolve(ParkingFlatRate flatRate);
    }
}
