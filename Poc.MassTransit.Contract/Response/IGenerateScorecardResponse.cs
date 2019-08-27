using System;
using System.Collections.Generic;
using System.Text;

namespace Poc.MassTransit.Contract.Response
{
    public interface IGenerateScorecardResponse
    {
        public int WpbYear { get; }
    }
}
