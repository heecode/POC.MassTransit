using log4net.Config;
using MassTransit.Log4NetIntegration.Logging;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using Topshelf;
using Topshelf.Logging;
using Topshelf.Unity;

namespace Poc.MassTransit.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigureLogger();

            // Topshelf to use Log4Net
            Log4NetLogWriterFactory.Use();

            // MassTransit to use Log4Net
            Log4NetLogger.Use();

            var container = IocConfig.RegisterDependencies();


            HostFactory.Run(cfg =>
            {

                cfg.UseUnityContainer(container);

                cfg.Service<ClientService>(s =>
                {
                    s.ConstructUsingUnityContainer();
                    s.WhenStarted((service, cfg) => service.Start(cfg));
                    s.WhenStopped((service, cfg) => service.Stop(cfg));
                });
            });


        }

        static void ConfigureLogger()
        {
            const string logConfig = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<log4net>
  <root>
    <level value=""INFO"" />
    <appender-ref ref=""console"" />
  </root>
  <appender name=""console"" type=""log4net.Appender.AnsiColorTerminalAppender"">
    <layout type=""log4net.Layout.PatternLayout"">
      <conversionPattern value=""%m%n"" />
    </layout>
  </appender>
</log4net>";

            // XmlDocument log4netConfig = new XmlDocument();
            // log4netConfig.Load(File.OpenRead("log4net.config"));
            var repo = log4net.LogManager.CreateRepository(Assembly.GetEntryAssembly(),
                       typeof(log4net.Repository.Hierarchy.Hierarchy));

            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(logConfig)))
            {
                XmlConfigurator.Configure(repo, stream);
            }
        }
    }
}
