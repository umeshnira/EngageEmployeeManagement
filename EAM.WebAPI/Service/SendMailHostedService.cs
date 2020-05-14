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
    public class SendMailHostedService : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly ILogger<SendMailHostedService> _logger;
        private readonly IOptions<HostedServiceOptions> _options;
        private readonly SendMailSingleton _tasks;
        public SendMailHostedService(ILogger<SendMailHostedService> logger, IOptions<HostedServiceOptions> options, SendMailSingleton tasks)
        {
            _logger = logger;
            _options = options;
            _tasks = tasks;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                var interval = _options.Value.SendMailServiceDurationInSeconds;
                _timer = new Timer(ExecuteAtInterval, null, 0, interval * 1000);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "SendMail Service statup error");
            }
            return Task.CompletedTask;
        }

        void ExecuteAtInterval(object state)
        {
            //Debug.Print(_options.Value.MinutesToExpire.ToString());
            _tasks.ExecSendMail(10);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Debug.Print("Send Mail Service exiting"); // when function is executing
            _tasks.stop = true;
            //New Timer does not have a stop. 
            _timer?.Change(Timeout.Infinite, 0);
            _timer?.Dispose();
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            Debug.Print("Send Mail Service disposing"); // when error is raised

            _tasks.stop = true;
            _timer?.Dispose();
        }

    }
}

