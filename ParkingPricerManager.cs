using System;

namespace ParkingPricer
{
    public class ParkingPricerManager
    {
        private int _flatRate;
        private string _duration;

        public ParkingPricerManager(int flatRate, string duration)
        {
            _flatRate = flatRate;
            _duration = duration;
        }

        public void ShowActualPrice()
        {
            
        }
    }
}