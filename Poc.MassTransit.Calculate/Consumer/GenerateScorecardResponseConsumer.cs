using MassTransit;
using MassTransit.Logging;
using Poc.MassTransit.Calculate.Response;
using Poc.MassTransit.Contract.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Poc.MassTransit.Calculate.Consumer
{
    public class GenerateScorecardResponseConsumer : IConsumer<IGenerateScorecardRequest>
    {
        readonly ILog _log = Logger.Get<GenerateScorecardResponseConsumer>();
        readonly IBusControl _bus;

        public GenerateScorecardResponseConsumer(IBusControl bus)
        {

            _bus = bus;

        }

        public async Task Consume(ConsumeContext<IGenerateScorecardRequest> context)
        {

            context.Respond(new GenerateScorecardResponse
            {
                WpbYear = context.Message.WpbYear * 7
            });
        }


    }
}
