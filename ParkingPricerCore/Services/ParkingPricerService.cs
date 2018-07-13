using System;
using System.Collections.Generic;
using System.Text;
using ParkingPricerCore.Contracts;
using ParkingPricerCore.Managers;
using ParkingPricerCore.Resolvers;

namespace ParkingPricerCore.Services
{
    public class ParkingPricerService : IParkingPricerService
    {
        private readonly IConsole _logger;
        private readonly IParkingPriceResolver _resolver;

        public ParkingPricerService(IConsole logger, IParkingPriceResolver resolver)
        {
            _logger = logger;
            _resolver = resolver;
        }

        public void Start()
        {
            string flatRate = ShowFlatRateMenu();
            string duration = ShowDurationMenu();

            try
            {
                var price = _resolver
                    .Resolve(ConvertToFlatRateEnum(flatRate))
                    .GetPrice(duration);

                _logger.Write($"Le prix calculé est de ${ price }.");
            }
            catch (ArgumentException ex)
            {
                _logger.Write(ex.Message);
            }
        }

        private ParkingFlatRate ConvertToFlatRateEnum(string flatRate)
        {
            if (!Enum.TryParse(flatRate, out ParkingFlatRate parkingFlatRate))
                throw new ArgumentException("Le forfait sélectionné est incorrect");

            return parkingFlatRate;
        }

        private static string ShowFlatRateMenu()
        {
            var menu = new ConsoleMenu("Veuillez entrer un forfait :");

            menu.AddOption(ParkingFlatRate.ShortDuration.ToString(), "Courte durée");
            menu.AddOption(ParkingFlatRate.Floor.ToString(), "Etagé");
            menu.AddOption(ParkingFlatRate.ValetParc.ToString(), "Valet parc");

            string flatRate = menu.Show();
            return flatRate;
        }

        private string ShowDurationMenu()
        {
            _logger.AddEmptyLine();
            _logger.Write("Veuillez entrer une durée (en h) : ");

            var duration = _logger.Read();

            _logger.AddEmptyLine();
            return duration;
        }
    }

    public interface IConsole
    {
        void Write(string message);
        void AddEmptyLine();
        string Read();
    }

    public class SystemConsole : IConsole
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }

        public void AddEmptyLine()
        {
            Console.WriteLine();
        }

        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
