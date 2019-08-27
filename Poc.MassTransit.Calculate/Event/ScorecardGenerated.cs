using Poc.MassTransit.Contract.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poc.MassTransit.Calculate.Event
{
    public class ScorecardGenerated : IScorecardGenerated
    {
        public string WpbYear { get; set; }
    }
}
