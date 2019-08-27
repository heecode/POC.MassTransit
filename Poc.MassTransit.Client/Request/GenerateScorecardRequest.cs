using Poc.MassTransit.Contract.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poc.MassTransit.Client.Request
{
    public class GenerateScorecardRequest : IGenerateScorecardRequest
    {
        public int WpbYear { get; set; }
    }
}
