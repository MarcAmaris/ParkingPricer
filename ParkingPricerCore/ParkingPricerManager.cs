using System;

namespace ParkingPricer
{
    public class ParkingPricerManager
    {
        public void ShowActualPrice(string flatRateStr, string durationStr)
        {
            ParkingFlatRate parkingFlatRate;
            if (!Enum.TryParse(flatRateStr, out parkingFlatRate)) throw new ArgumentException("Le forfait sélectionné est incorrect");

            int duration = 0;
            if (!int.TryParse(durationStr, out duration)) throw new ArgumentException("La durée entrée est incorrecte");
        }
    }

    public enum ParkingFlatRate
    {
        ShortDuration = 0,
        Floor,
        ValetParc
    }
}