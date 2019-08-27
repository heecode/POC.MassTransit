using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Poc.MassTransit.ClientWeb.Command;
using Poc.MassTransit.Infrastructure;

namespace Poc.MassTransit.ClientWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateController : ControllerBase
    {

        IBus _bus;
        IOptions<MassTransitConfig> _op;


        public CalculateController(IBus bus, IOptions<MassTransitConfig> op)
        {
            _bus = bus;
            _op = op;
        }

        [HttpGet]
        public async Task<IActionResult> Calculate(int wpbYear)
        {
            var url = _op.Value.Host + "/" + MassTransitQueue.GenerateScorecard;
            var sendEndpoint = await _bus.GetSendEndpoint(new Uri(url));
            await sendEndpoint.Send<GenerateScorecard>(new
            {
                WpbYear = wpbYear
            });

            return Accepted();
        }


    }
}