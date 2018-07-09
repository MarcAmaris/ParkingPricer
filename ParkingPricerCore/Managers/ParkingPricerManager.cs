using System;
using System.Globalization;

namespace ParkingPricer
{
    public abstract class ParkingPricerManager : IParkingPricerManager
    {
        #region Abstract Members
        /// <summary>
        /// Price limit per day bqsed on selected flat rate
        /// </summary>
        public abstract int DayPriceLimit { get; }

        /// <summary>
        /// Price based on selected flat rate
        /// </summary>
        public abstract int PricePerFlatRate  { get; }
        #endregion

        public int GetPrice(string durationStr)
        {
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

            return CalculatePrice(duration);
        }

        /// <summary>
        /// Calculate real price based on given price and selected flat rate
        /// </summary>
        /// <param name="parkingFlatRate"></param>
        /// <param name="theoricalPrice"></param>
        /// <returns></returns>
        private int CalculatePrice(decimal duration)
        {
            // get hours digit of duration
            int hours = (int)Math.Truncate(duration);
            // get number of days in duration
            int days = (int)Math.Floor((double)(hours/24));

            // calculate price per day chose using price limit
            int daysPrice = days * DayPriceLimit;
            
            // get mins of duration as actual min (ex: 1.5, get 0.5 as min => 30)
            int mins = (int)((duration - hours) * 60);            
            // get remaining time modulo days as mins to calculate remaining price
            // 25.5 as duration = 1.5 hour remaining = 90min
            int remainingMinutes = ((hours - (days * 24)) * 60) + mins;

            // get time periods from remaining min, divided by span of 20min
            int minutesPeriods = (int)Math.Ceiling((decimal)remainingMinutes / (decimal)Consts.DurationTimePeriod);
            int remainingTimePrice = minutesPeriods * PricePerFlatRate;
            // price cannot exceed given amount per flatrate
            if (remainingTimePrice > DayPriceLimit) remainingTimePrice = DayPriceLimit;
            return daysPrice + remainingTimePrice;
        }
    }
}