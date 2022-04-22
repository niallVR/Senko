using Discord;
using Discord.Interactions;
using Microsoft.Extensions.Logging;
using NiallVR.Senko.Bootstrap.Hosted.Abstract;
using NiallVR.Senko.Discord.Hosting.Extensions;

namespace NiallVR.Senko.Discord.Hosting.Services; 

public class InteractionsServiceLogService : HostedService {
    private readonly ILogger<InteractionService> _logger;

    public InteractionsServiceLogService(ILogger<InteractionService> logger, InteractionService? interaction = null) {
        _logger = logger;
        if (interaction is not null)
            interaction.Log += OnLog;
    }

    private Task OnLog(LogMessage logMessage) {
        _logger.Log(logMessage.Severity.ToLogLevel(), logMessage.Exception, logMessage.Message);
        return Task.CompletedTask;
    }
}