using System;
using System.Collections.Generic;
using System.Text;

namespace Poc.MassTransit.Contract.Event
{
    public interface IScorecardGenerated
    {
        public string WpbYear { get; set; }
    }
}
