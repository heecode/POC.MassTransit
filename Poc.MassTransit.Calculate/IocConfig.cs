using GreenPipes;
using GreenPipes.Introspection;
using MassTransit;
using MassTransit.Saga;
using Poc.MassTransit.Calculate.Consumer;
using Poc.MassTransit.Calculate.Services;
using Poc.MassTransit.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Unity;
using Unity.Lifetime;

namespace Poc.MassTransit.Calculate
{
    public class IocConfig
    {
        public static IUnityContainer RegisterDependencies()
        {
            var container = new UnityContainer();

            container.RegisterType<CalculateService>();
            container.RegisterType<IBusinessSaga, Saga>();
            container.RegisterType<IServices, BusinessServices>();



            container.RegisterType<GenerateScorecardConsumer>(new ContainerControlledLifetimeManager());
            container.RegisterType<ScorecardGeneratedConsumer>(new ContainerControlledLifetimeManager());
            container.RegisterType<GenerateScorecardResponseConsumer>(new ContainerControlledLifetimeManager());

            var  config = MassTransitConfigurationManager.Config;

            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri(config.Host), h =>
                {
                    h.Username(config.Username);
                    h.Password(config.Password);
                });

                cfg.ReceiveEndpoint(host, MassTransitQueue.GenerateScorecard,
                    e => { e.Consumer<GenerateScorecardConsumer>(container); });
                cfg.ReceiveEndpoint(host, MassTransitQueue.ScorecardGenerated,
                   e => { e.Consumer<ScorecardGeneratedConsumer>(container); });
                cfg.ReceiveEndpoint(host, MassTransitQueue.GenerateScorecardResponse,
                  e => { e.Consumer<GenerateScorecardResponseConsumer>(container); });





            });

            

            container.RegisterInstance<IBusControl>(busControl);
            container.RegisterInstance<IBus>(busControl);



            return container;
        }
    }
}
