using System;

namespace ParkingPricer
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new Menu("Please select flat rate:");
            menu.AddOption("20min");
            menu.AddOption("24h");

            int selectedOption = menu.Show();

            Console.WriteLine("Please enter duration:");
            var duration = Console.ReadLine();

            var parkingPricingManager = new ParkingPricerManager();
            parkingPricingManager.ShowActualPrice();
        }
    }
}
