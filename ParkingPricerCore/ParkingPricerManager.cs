using System;
using System.Globalization;

namespace ParkingPricer
{
    public class ParkingPricerManager
    {
        public int GetPrice(string flatRateStr, string durationStr)
        {
            ParkingFlatRate parkingFlatRate;
            if (!Enum.TryParse(flatRateStr, out parkingFlatRate)) throw new ArgumentException("Le forfait sélectionné est incorrect");

            if (string.IsNullOrWhiteSpace(durationStr)) throw new ArgumentException("Veuillez entrer une valeur");
            durationStr = durationStr.Replace(",", ".");
            decimal duration = 0;
            // set dot as decimal separator
            var numberFormatInfo = new NumberFormatInfo { NumberDecimalSeparator = "." };
            if (!decimal.TryParse(durationStr, NumberStyles.AllowDecimalPoint, numberFormatInfo, out duration) 
                || duration < 0)
            {
                throw new ArgumentException("La durée entrée est incorrecte");
            }

            return CalculatePrice(parkingFlatRate, duration);
        }

        /// <summary>
        /// Calculate real price based on given price and selected flat rate
        /// </summary>
        /// <param name="parkingFlatRate"></param>
        /// <param name="theoricalPrice"></param>
        /// <returns></returns>
        private int CalculatePrice(ParkingFlatRate parkingFlatRate, decimal duration)
        {
            // get hours digit of duration
            int hours = (int)Math.Truncate(duration);
            // get number of days in duration
            int days = (int)Math.Floor((double)(hours/24));

            // get price limit per day per flat rate
            int priceLimit = GetDayPriceLimit(parkingFlatRate);
            // calculate price per day chose using price limit
            int daysPrice = days * priceLimit;
            
            // get mins of duration as actual min (ex: 1.5, get 0.5 as min => 30)
            int mins = (int)((duration - hours) * 60);            
            // get remaining time modulo days as mins to calculate remaining price
            // 25.5 as duration = 1.5 hour remaining = 90min
            int remainingMinutes = ((hours - (days * 24)) * 60) + mins;

            // get time periods from remaining min, divided by span of 20min
            int minutesPeriods = (int)Math.Ceiling((decimal)remainingMinutes / (decimal)Consts.DurationTimePeriod);
            int pricePerFlatRate = GetPricePerFlatRate(parkingFlatRate);
            int remainingTimePrice = minutesPeriods * pricePerFlatRate;
            // price cannot exceed given amount per flatrate
            if (remainingTimePrice > priceLimit) remainingTimePrice = priceLimit;
            return daysPrice + remainingTimePrice;
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

        public int GetDayPriceLimit(ParkingFlatRate flatRate)
        {
            switch (flatRate)
            {
                case ParkingFlatRate.ShortDuration: return Consts.ShortDurationLimitPrice;
                case ParkingFlatRate.Floor: return Consts.FloorLimitPrice;
                case ParkingFlatRate.ValetParc: return Consts.ValetParcLimitPrice;
                default:
                    throw new ArgumentException("Le forfait sélectionné est incorrect");
            }
        }
    }

    public enum ParkingFlatRate
    {
        ShortDuration = 0,
        Floor,
        ValetParc
    }
}