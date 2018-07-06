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
            menu.AddOption(ParkingFlatRate.ShortDuration.ToString(), "Courte durée");
            menu.AddOption(ParkingFlatRate.Floor.ToString(),"Etagé");
            menu.AddOption(ParkingFlatRate.ValetParc.ToString(), "Valet parc");

            string flatRate = menu.Show();

            Console.WriteLine();
            Console.Write("Veuillez entrer une durée (en min) : ");
            var duration = Console.ReadLine();
            Console.WriteLine();

            var parkingPricingManager = new ParkingPricerManager();
            
            try
            {
                int price = parkingPricingManager.GetActualPrice(flatRate, duration);
                Console.WriteLine("Le prix calculé est de ${0}.", price);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}