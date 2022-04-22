using Discord.Interactions;

namespace Senko.Discord.Example.Commands; 

public class GreetingCommands : InteractionModuleBase {
    [SlashCommand("hello", "Sends a greeting")]
    public async Task HelloCommand() {
        await RespondAsync($"Hello {Context.User.Username}!");
    }
}