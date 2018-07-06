using System;

namespace ParkingPricer
{
    public class ParkingPricerManager
    {
        public int GetActualPrice(string flatRateStr, string durationStr)
        {
            ParkingFlatRate parkingFlatRate;
            if (!Enum.TryParse(flatRateStr, out parkingFlatRate)) throw new ArgumentException("Le forfait sélectionné est incorrect");

            int duration = 0;
            if (!int.TryParse(durationStr, out duration) || duration < 0) throw new ArgumentException("La durée entrée est incorrecte");

            // calculate how much 20 min periods in duration there is
            int durationTime = (int)Math.Ceiling((decimal)duration / (decimal)Consts.DurationTimePeriod);

            // get theorical price without checking 24h period            
            int pricePerFlatRate = GetPricePerFlatRate(parkingFlatRate);
            int theoricalPrice = (int)(durationTime * pricePerFlatRate);

            return GetRealPrice(parkingFlatRate, theoricalPrice);
        }

        /// <summary>
        /// Get price based on selected flat rate
        /// </summary>
        /// <param name="flatRate">selected flat rate</param>
        /// <returns></returns>
        public int GetPricePerFlatRate(ParkingFlatRate flatRate)
        {
            switch (flatRate)
            {
                case ParkingFlatRate.ShortDuration:
                case ParkingFlatRate.Floor: return Consts.ShortDurationAndFloorPrice;
                case ParkingFlatRate.ValetParc: return Consts.ValetParcPrice;
                default:
                    throw new ArgumentException("Le forfait sélectionné est incorrect");
            }
        }       
        
        /// <summary>
        /// Calculate real price based on given price and selected flat rate
        /// </summary>
        /// <param name="parkingFlatRate"></param>
        /// <param name="theoricalPrice"></param>
        /// <returns></returns>
        public int GetRealPrice(ParkingFlatRate parkingFlatRate, int theoricalPrice)
        {
            int priceLimit = 0;
            switch (parkingFlatRate)
            {                
                case ParkingFlatRate.ShortDuration: 
                    priceLimit = Consts.ShortDurationLimitPrice;
                    break;
                case ParkingFlatRate.Floor:
                    priceLimit = Consts.FloorLimitPrice;
                    break;
                case ParkingFlatRate.ValetParc: 
                    priceLimit = Consts.ValetParcLimitPrice;
                    break;
                default:
                    throw new ArgumentException("Le forfait sélectionné est incorrect");
            }

            if (theoricalPrice > priceLimit) theoricalPrice = priceLimit;
            return theoricalPrice;
        }
    }

    public enum ParkingFlatRate
    {
        ShortDuration = 0,
        Floor,
        ValetParc
    }
}