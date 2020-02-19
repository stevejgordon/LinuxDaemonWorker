using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ConfigWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly string _valueFromConfig;

        public Worker(ILogger<Worker> logger, IConfiguration config)
        {
            _logger = logger;
            _valueFromConfig = config["ConfigValue"];
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogWarning($"Base Directory = {AppContext.BaseDirectory}");
            _logger.LogWarning($"Config value: {_valueFromConfig}");

            while (!stoppingToken.IsCancellationRequested)
            { 
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
