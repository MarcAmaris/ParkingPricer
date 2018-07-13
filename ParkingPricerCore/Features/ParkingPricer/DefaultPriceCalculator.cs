using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingPricerCore.Features
{
    public class DefaultPriceCalculator : IPriceCalculator
    {
        public int CalculatePrice(decimal duration, int dayPriceLimit, int pricePerFlateRate)
        {
            int daysPrice = GetFullDaysPrice(dayPriceLimit, duration);
            int remainingTimePrice = GetRemainingTimePrice(duration, pricePerFlateRate, dayPriceLimit);

            return daysPrice + remainingTimePrice;
        }

        private int GetFullDaysPrice(int dayPriceLimit, decimal duration)
        {
            int hours = GetHours(duration);
            int days = GetDays(hours);

            return days * dayPriceLimit;
        }

        private int GetRemainingTimePrice(decimal duration, int pricePerFlateRate, int dayPriceLimit)
        {
            int remainingMinutes = GetRemainingMinutesNumber(duration);

            int minutesPeriods = (int)Math.Ceiling((decimal)remainingMinutes / (decimal)Consts.DurationTimePeriod);
            int remainingTimePrice = minutesPeriods * pricePerFlateRate;

            if (remainingTimePrice > dayPriceLimit) remainingTimePrice = dayPriceLimit;

            return remainingTimePrice;
        }

        private int GetRemainingMinutesNumber(decimal duration)
        {
            int mins = GetRemainingMinutes(duration);
            int hours = GetHours(duration);
            int days = GetDays(hours);

            return ((hours - (days * 24)) * 60) + mins;
        }

        private int GetRemainingMinutes(decimal duration)
        {
            int hours = GetHours(duration);

            return (int)((duration - hours) * 60);
        }

        private int GetDays(int hours)
        {
            return (int)Math.Floor((double)(hours / 24));
        }

        private int GetHours(decimal duration)
        {
            return (int)Math.Truncate(duration);
        }
    }
}
