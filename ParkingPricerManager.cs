using System;

namespace ParkingPricer
{
    public class ParkingPricerManager
    {
        public void ShowActualPrice(string flatRateStr, string durationStr)
        {
            ParkingFlatRate parkingFlatRate;
            if (!Enum.TryParse(flatRateStr, out parkingFlatRate))
            {
                Console.WriteLine("Le forfait sélectionné est incorrect");
                return;
            }

            int duration = 0;
            if (!int.TryParse(durationStr, out duration))
            {
                Console.WriteLine("La durée entrée est incorrecte");
                return;
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