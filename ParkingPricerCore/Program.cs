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
            string flatRate = ShowFlatRateMenu();
            string duration = ShowDurationMenu();

            var parkingPricingManager = new ParkingPricerManager();
            
            try
            {
                int price = parkingPricingManager.GetPrice(flatRate, duration);
                Console.WriteLine("Le prix calculé est de ${0}.", price);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static string ShowFlatRateMenu()
        {
            var menu = new ConsoleMenu("Veuillez entrer un forfait :");
            menu.AddOption(ParkingFlatRate.ShortDuration.ToString(), "Courte durée");
            menu.AddOption(ParkingFlatRate.Floor.ToString(),"Etagé");
            menu.AddOption(ParkingFlatRate.ValetParc.ToString(), "Valet parc");

            string flatRate = menu.Show();
            return flatRate;
        }

        private static string ShowDurationMenu()
        {
            Console.WriteLine();
            Console.Write("Veuillez entrer une durée (en h) : ");
            var duration = Console.ReadLine();
            Console.WriteLine();
            return duration;
        }
    }
}