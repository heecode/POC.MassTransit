using Poc.MassTransit.Contract.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poc.MassTransit.ClientWeb.Command
{
    public class GenerateScorecard : IGenerateScorecard
    {
        public int WpbYear { get; set; }
    }
}
