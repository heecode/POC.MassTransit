using System;
using System.Collections.Generic;
using System.Text;

namespace Poc.MassTransit.Contract.Request
{
    public interface IGenerateScorecardRequest
    {

        public int WpbYear { get; set; }

    }
}
