using EAM.Common.Entities;
using EAM.Data;
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

namespace EAM.WebAPI.Service
{
    public class EAMHostedService : IHostedService
    {
        private Timer _timer;
        private readonly ILogger<EAMHostedService> _logger;
        private readonly IOptions<JWTOptions> _options;
        private readonly TaskSingleton _tasks;
        private volatile bool stop = false;
        public EAMHostedService(ILogger<EAMHostedService> logger, IOptions<JWTOptions> options, TaskSingleton tasks)
        {
            _logger = logger;
            _options = options;
            _tasks = tasks;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(ExecuteAtInterval, null, 0, 10000);
            return Task.CompletedTask;
        }

        void ExecuteAtInterval(object state)
        {
            //Debug.Print(_options.Value.MinutesToExpire.ToString());
            _tasks.ExecDeleteNotifications(stop, 10);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            stop = true;
            //New Timer does not have a stop. 
            _timer?.Change(Timeout.Infinite, 0);
            _timer?.Dispose();
            return Task.CompletedTask;
        }
    }
}
