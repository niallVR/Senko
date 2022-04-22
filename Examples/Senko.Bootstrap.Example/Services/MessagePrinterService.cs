using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Senko.Bootstrap.Example.Config;

namespace Senko.Bootstrap.Example.Services; 

public class MessagePrinterService : BackgroundService {
    private readonly MessageConfig _config;
    private readonly ILogger<MessagePrinterService> _logger;

    public MessagePrinterService(MessageConfig config, ILogger<MessagePrinterService> logger) {
        _config = config;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
        _logger.LogInformation("Starting the message printer service");
        while (!stoppingToken.IsCancellationRequested) {
            await Task.Delay(TimeSpan.FromSeconds(_config.Interval), stoppingToken);
            await Console.Out.WriteLineAsync(_config.Content);
        }
    }
}