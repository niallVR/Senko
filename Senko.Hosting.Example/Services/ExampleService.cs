using Microsoft.Extensions.Logging;
using NiallVR.Senko.Hosting.Hosted.Abstract;
using Senko.Hosting.Example.Config;

namespace Senko.Hosting.Example.Services; 

public class ExampleService : HostedService {
    private readonly ExampleConfig _exampleConfig;
    private readonly ILogger<ExampleService> _logger;

    public ExampleService(ExampleConfig exampleConfig, ILogger<ExampleService> logger) {
        _exampleConfig = exampleConfig;
        _logger = logger;
    }

    public override Task StartAsync(CancellationToken cancellationToken) {
        _logger.LogInformation("The configured value is {Value}", _exampleConfig.TestString);
        return Task.CompletedTask;
    }
}