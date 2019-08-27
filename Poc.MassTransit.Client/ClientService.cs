using MassTransit;
using MassTransit.Util;
using Poc.MassTransit.Client.Command;
using Poc.MassTransit.Client.Request;
using Poc.MassTransit.Contract.Request;
using Poc.MassTransit.Contract.Response;
using Poc.MassTransit.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.Logging;

namespace Poc.MassTransit.Client
{
    class ClientService : ServiceControl
    {
        readonly LogWriter _log = HostLogger.Get<ClientService>();
        IBusControl _busControl;
        IRequestClient<IGenerateScorecardRequest, IGenerateScorecardResponse> _generateScorecard;
        public ClientService(IBusControl busControl, IRequestClient<IGenerateScorecardRequest, IGenerateScorecardResponse> generateScorecard)
        {
            _busControl = busControl;
            _generateScorecard = generateScorecard;
        }
        public bool Start(HostControl hostControl)
        {
            _log.Info("Creating bus...");
            _log.Info("Starting bus...");

            TaskUtil.Await(() => _busControl.StartAsync());
            var config = MassTransitConfigurationManager.Config;

            try
            {
               
                for (; ; )
                {
                    Console.Write("Enter Number (quit exits): ");
                    string customerId = Console.ReadLine();
                    if (customerId == "quit")
                        break;

                    // this is run as a Task to avoid weird console application issues
                    Task.Run(async () =>
                    {
                        //Request - Response
                        var response = await _generateScorecard.Request(new GenerateScorecardRequest { WpbYear = int.Parse(customerId) });
                        Console.WriteLine("This Is From Response: {0}", response.WpbYear);

                        //Send Command
                        var url = config.Host + "/" + MassTransitQueue.GenerateScorecard;
                        var sendEndpoint = await _busControl.GetSendEndpoint(new Uri(url));
                        await sendEndpoint.Send<GenerateScorecard>(new
                        {
                            WpbYear = int.Parse(customerId)
                        });

                    }).Wait();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception!!! OMG!!! {0}", ex);
            }
            finally
            {
                _busControl.Stop();
            }

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            _busControl.Stop();
            return true;
        }
    }
}
