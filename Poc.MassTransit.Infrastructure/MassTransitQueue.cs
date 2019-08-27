using System;
using System.Collections.Generic;
using System.Text;

namespace Poc.MassTransit.Infrastructure
{
    public static class MassTransitQueue
    {
        public const string GenerateScorecard = "request_service";
        public const string ScorecardGenerated = "ScorecardGenerated";
        public const string ScorecardGeneratedEmail = "ScorecardGeneratedEmail";
        public const string GenerateScorecardResponse = "ResponseServiceAddress";

    }
}
