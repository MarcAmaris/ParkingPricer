using System;

namespace ParkingPricer
{
    public static class ParkingPricerFactory
    {
        public static IParkingPricerManager Create(string flatRateStr)
        {
            ParkingFlatRate parkingFlatRate;
            if (!Enum.TryParse(flatRateStr, out parkingFlatRate)) throw new ArgumentException("Le forfait sélectionné est incorrect");

            switch (parkingFlatRate)
            {
                case ParkingFlatRate.ShortDuration: return new ShortDurationParkingPricerManager();
                case ParkingFlatRate.Floor: return new FloorParkingPricerManager();
                case ParkingFlatRate.ValetParc: return new ValetParcParkingPricerManager();
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