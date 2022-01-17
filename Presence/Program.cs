using Discord;
using Discord.WebSocket;
using Presence.Services.Loggers;

namespace Presence;

public class Program
{

    public static Task Main(string[] args) => new Program().MainAsync();

    private async Task MainAsync()
    {
        DiscordSocketClient client = new();
        EventLogger _logger = new(client);
        string? token = Environment.GetEnvironmentVariable("TOKEN") ?? 
                        throw new ArgumentNullException(nameof(token));
        
        client.Log += _logger.ClientLogger;
        await client.LoginAsync(TokenType.Bot, token);
        await client.StartAsync();

        await Task.Delay(-1);
    }
}

