using MassTransit;
using Poc.MassTransit.Contract.Request;
using Poc.MassTransit.Contract.Response;
using Poc.MassTransit.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Unity;

namespace Poc.MassTransit.Client
{
 public  class IocConfig
    {
        public static IUnityContainer RegisterDependencies()
        {
            var container = new UnityContainer();

            container.RegisterType<ClientService>();



            var config = MassTransitConfigurationManager.Config;

            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri(config.Host), h =>
                {
                    h.Username(config.Username);
                    h.Password(config.Password);
                });              





            });

            //busControl.rec

            container.RegisterInstance<IBusControl>(busControl);
            container.RegisterInstance<IBus>(busControl);
            container.RegisterInstance<IRequestClient<IGenerateScorecardRequest, IGenerateScorecardResponse>>(CreateRequestClient(busControl));



            return container;
        }

        static IRequestClient<IGenerateScorecardRequest, IGenerateScorecardResponse> CreateRequestClient(IBusControl busControl)
        {
            var config = MassTransitConfigurationManager.Config;

            var url = config.Host + "/" + MassTransitQueue.GenerateScorecardResponse;
            var serviceAddress = new Uri(url);
            IRequestClient<IGenerateScorecardRequest, IGenerateScorecardResponse> client =
                busControl.CreateRequestClient<IGenerateScorecardRequest, IGenerateScorecardResponse>(serviceAddress, TimeSpan.FromSeconds(10));

            return client;
        }
    }
}
