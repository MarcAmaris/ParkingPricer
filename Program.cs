using System;

namespace ParkingPricer
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculateParkingPrice();
        }

        private static void CalculateParkingPrice()
        {
            var menu = new ConsoleMenu("Veuillez entrer un forfait :");
            menu.AddOption("Courte durée");
            menu.AddOption("Etagé");
            menu.AddOption("Valet parc");

            int selectedOption = menu.Show();

            Console.WriteLine();

            Console.Write("Veuillez entrer une durée : ");
            var duration = Console.ReadLine();

            var parkingPricingManager = new ParkingPricerManager(selectedOption, duration);
            parkingPricingManager.ShowActualPrice();
        }
    }
}