using System;
using System.Collections.Generic;
using System.Text;

namespace Poc.MassTransit.Contract.Command
{
    public interface IGenerateScorecard
    {
        public int WpbYear { get; set; }
    }
}
