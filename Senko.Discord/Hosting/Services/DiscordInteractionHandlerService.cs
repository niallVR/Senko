using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NiallVR.Senko.Discord.Hosting.Models;
using NiallVR.Senko.Hosting.Abstract;

namespace NiallVR.Senko.Discord.Hosting.Services;

/// <summary>
/// Manages the interaction service if it's enabled.
/// </summary>
internal class DiscordInteractionHandlerService : HostedService {
    private readonly IServiceProvider _services;
    private readonly InteractionService _interactionService;
    private readonly DiscordSocketClient _discord;
    private readonly ILogger<DiscordInteractionHandlerService> _logger;

    public DiscordInteractionHandlerService(IServiceProvider services) {
        _services = services;
        _logger = services.GetRequiredService<ILogger<DiscordInteractionHandlerService>>();
        _interactionService = services.GetRequiredService<InteractionService>();
        _interactionService.SlashCommandExecuted += HandleInteractionResult;
        _interactionService.ContextCommandExecuted += HandleInteractionResult;
        
        _discord = services.GetRequiredService<DiscordSocketClient>();
        _discord.SlashCommandExecuted += HandleSlashCommandInteraction;
        _discord.UserCommandExecuted += HandleSlashCommandInteraction;
        _discord.MessageCommandExecuted += HandleSlashCommandInteraction;
    }

    /// <summary>
    /// Passes the slash command interaction to the interaction service.
    /// </summary>
    private async Task HandleSlashCommandInteraction(SocketInteraction arg) {
        try {
            await _interactionService.ExecuteCommandAsync(new SocketInteractionContext(_discord, arg), _services);
        } catch (Exception error) {
            _logger.LogError(error, "An exception occurred whilst handling a interaction");
        }
    }

    /// <summary>
    /// Handles the result of a slash command interaction.
    /// </summary>
    private static async Task HandleInteractionResult(IApplicationCommandInfo _, IInteractionContext ctx, IResult result) {
        if (result.IsSuccess)
            return;

        var response = result.Error switch {
            InteractionCommandError.UnknownCommand => "Sorry, I don't know anything about the command you just used!",
            InteractionCommandError.ConvertFailed => "Invalid arguments!",
            InteractionCommandError.BadArgs => "Invalid arguments!",
            InteractionCommandError.ParseFailed => "Invalid arguments!",
            InteractionCommandError.UnmetPrecondition => result.ErrorReason,
            InteractionCommandError.Unsuccessful => "Sorry, something went wrong! Please try again later.",
            InteractionCommandError.Exception => "Sorry, something went wrong! Please try again later.",
            _ => "Sorry, something went wrong! Please try again later."
        };

        try {
            await ctx.Interaction.RespondAsync(response);
        } catch {
            await ctx.Interaction.FollowupAsync(response);
        }
    }
}