using MassTransit;
using MassTransit.Logging;
using Poc.MassTransit.Contract.Event;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Poc.MassTransit.Email.Consumer
{
    class ScorecardGeneratedConsumer : IConsumer<IScorecardGenerated>
    {
        readonly ILog _log = Logger.Get<ScorecardGeneratedConsumer>();


        public async Task Consume(ConsumeContext<IScorecardGenerated> context)
        {
            _log.InfoFormat("Send To {0} Email", context.Message.WpbYear + "iHeemi@yahoo.com");
        }


    }
}
