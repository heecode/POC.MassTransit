using MassTransit;
using Poc.MassTransit.Email.Consumer;
using Poc.MassTransit.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using Unity.Lifetime;

namespace Poc.MassTransit.Email
{
    public class IocConfig
    {
        public static IUnityContainer RegisterDependencies()
        {
            var container = new UnityContainer();

            container.RegisterType<EmailService>();





            container.RegisterType<ScorecardGeneratedConsumer>(new ContainerControlledLifetimeManager());
            var config = MassTransitConfigurationManager.Config;


            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri(config.Host), h =>
                {
                    h.Username(config.Username);
                    h.Password(config.Password);
                });


                cfg.ReceiveEndpoint(host, MassTransitQueue.ScorecardGeneratedEmail,
                   e => { e.Consumer<ScorecardGeneratedConsumer>(container); });




            });



            container.RegisterInstance<IBusControl>(busControl);
            container.RegisterInstance<IBus>(busControl);



            return container;
        }
    }
}
