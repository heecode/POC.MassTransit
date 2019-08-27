using Poc.MassTransit.Contract.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poc.MassTransit.Calculate.Response
{
    public class GenerateScorecardResponse : IGenerateScorecardResponse
    {
        public int WpbYear { get; set; }
    }
}
