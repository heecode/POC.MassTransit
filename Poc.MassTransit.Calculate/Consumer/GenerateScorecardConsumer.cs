using MassTransit;
using MassTransit.Logging;
using Poc.MassTransit.Calculate.Event;
using Poc.MassTransit.Calculate.Services;
using Poc.MassTransit.Contract.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Poc.MassTransit.Calculate.Consumer
{
    public class GenerateScorecardConsumer : IConsumer<IGenerateScorecard>
    {
        readonly ILog _log = Logger.Get<GenerateScorecardConsumer>();
        readonly IBusControl _bus;
        readonly IServices _services;

        public GenerateScorecardConsumer(IBusControl bus, IServices services)
        {

            _bus = bus;
            _services = services;
        }

        public async Task Consume(ConsumeContext<IGenerateScorecard> context)
        {
            _log.InfoFormat("Command Value {0}", context.Message.WpbYear.ToString());

            var calculated = _services.MultiplyBy2(context.Message.WpbYear);

            //Publish event
            await _bus.Publish<ScorecardGenerated>(new { WpbYear = calculated.ToString() });

        }


    }
}
