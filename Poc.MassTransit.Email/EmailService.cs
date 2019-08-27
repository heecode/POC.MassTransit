using MassTransit;
using MassTransit.Util;
using System;
using System.Collections.Generic;
using System.Text;
using Topshelf;
using Topshelf.Logging;

namespace Poc.MassTransit.Email
{
    class EmailService : ServiceControl
    {
        readonly LogWriter _log = HostLogger.Get<EmailService>();
        IBusControl _busControl;

        public EmailService(IBusControl busControl)
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
