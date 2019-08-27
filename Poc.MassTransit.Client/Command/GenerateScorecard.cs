using Poc.MassTransit.Contract.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poc.MassTransit.Client.Command
{
    public class GenerateScorecard : IGenerateScorecard
    {
        public int WpbYear { get; set; }
    }
}
