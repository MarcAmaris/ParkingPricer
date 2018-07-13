using System;
using Autofac;
using ParkingPricerCore.Contracts;
using ParkingPricerCore.Features;
using ParkingPricerCore.Features.ParkingPricer.Pricers;
using ParkingPricerCore.Resolvers;
using ParkingPricerCore.Services;

namespace ParkingPricer.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ParkingPricerService>().As<IParkingPricerService>();
            builder.RegisterType<ParkingPriceResolver>().As<IParkingPriceResolver>();
            builder.RegisterType<SystemConsole>().As<IConsole>();
            builder.RegisterType<DecimalPointDurationFormatter>().As<IDurationFormatter>();
            builder.RegisterType<DefaultPriceCalculator>().As<IPriceCalculator>();

            builder.RegisterType<FloorPricer>().As<IParkingPriceStrategy>();
            builder.RegisterType<ShortDurationPricer>().As<IParkingPriceStrategy>();
            builder.RegisterType<ValetParcPricer>().As<IParkingPriceStrategy>();

            var container = builder.Build();

            var service = container.Resolve<IParkingPricerService>();
            service.Start();

            Console.ReadLine();
        }
    }
}
