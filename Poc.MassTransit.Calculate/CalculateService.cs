using MassTransit;
using MassTransit.Util;
using Topshelf;
using Topshelf.Logging;

namespace Poc.MassTransit.Calculate
{
    class CalculateService : ServiceControl
    {
        readonly LogWriter _log = HostLogger.Get<CalculateService>();
        IBusControl _busControl;


        BusHandle _busHandle;

        public CalculateService(IBusControl busControl)
        {
            _busControl = busControl;
        }
        public bool Start(HostControl hostControl)
        {
            _log.Info("Creating bus...");
            _log.Info("Starting bus...");

            TaskUtil.Await(() => _busControl.StartAsync());

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            TaskUtil.Await(() => _busControl.StopAsync());
            return true;
        }
    }
}
