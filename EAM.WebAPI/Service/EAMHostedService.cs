using EAM.Common.Entities;
using EAM.Application;
using EAM.Data.Repositories;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EAM.Application.SingletonServices;

namespace EAM.WebAPI.Service
{
    public class EAMHostedService : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly ILogger<EAMHostedService> _logger;
        private readonly IOptions<HostedServiceOptions> _options;
        private readonly IBSingleton<TaskService> _tasks;
        public EAMHostedService(ILogger<EAMHostedService> logger, IOptions<HostedServiceOptions> options, IBSingleton<TaskService> tasks)
        {
            _logger = logger;
            _options = options;
            _tasks = tasks;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                var interval = _options.Value.EAMServiceDurationInSeconds;
                _timer = new Timer(ExecuteAtInterval, null, 0, interval * 1000);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "EAM Service statup error");
            }
            return Task.CompletedTask;
        }

        void ExecuteAtInterval(object state)
        {
            //Debug.Print(_options.Value.MinutesToExpire.ToString());
            _tasks.provider.ExecDeleteNotifications(10);
            _tasks.provider.ExecTask2(10);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Debug.Print("EAM Service exiting");
            _tasks?.provider?.TryStop();
            //New Timer does not have a stop. 
            _timer?.Change(Timeout.Infinite, 0);
            _timer?.Dispose();
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            Debug.Print("EAM Service disposing");

            _tasks?.provider?.TryStop();
            _timer?.Dispose();
        }
    }
}
