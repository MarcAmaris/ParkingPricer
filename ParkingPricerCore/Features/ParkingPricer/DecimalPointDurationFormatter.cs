using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ParkingPricerCore.Features
{
    public class DecimalPointDurationFormatter: IDurationFormatter
    {
        public decimal Format(string duration)
        {
            if (string.IsNullOrWhiteSpace(duration))
                throw new ArgumentException("Veuillez entrer une valeur");

            duration = duration.Replace(",", ".");

            if (FormatDurationIsInvalid(duration, out decimal result) )
            {
                throw new ArgumentException("La durée entrée est incorrecte");
            }

            return result;
        }

        private bool FormatDurationIsInvalid(string duration, out decimal result)
        {
            var numberFormatInfo = new NumberFormatInfo { NumberDecimalSeparator = "." };
            return !decimal.TryParse(duration, NumberStyles.AllowDecimalPoint, numberFormatInfo, out result);
        }
    }

    public interface IDurationFormatter
    {
        decimal Format(string duration);
    }
}
