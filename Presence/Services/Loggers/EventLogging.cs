using System.Diagnostics.CodeAnalysis;
using System.IO;
using Discord;
using Discord.Commands;
using Discord.Rest;

namespace Presence.Services.Loggers;

public class EventLogger
{
    public EventLogger(BaseDiscordClient client)
    {
        if (!File.Exists("/Logs/client_logs.txt"))
            File.Create("/Logs/client_logs.txt");
        
        client.Log += ClientLogger;
    }
    public EventLogger(CommandService command)
    {
        if (!File.Exists("/Logs/command_logs.txt"))
            File.Create("/Logs/command_logs.txt");
        
        command.Log += CommandLogger;
    }
    
    // ReSharper disable once MemberCanBePrivate.Global
    [SuppressMessage("ReSharper", "MemberCanBeMadeStatic.Global")]
    [SuppressMessage("Performance", "CA1822:Mark members as static")]
    public Task CommandLogger(LogMessage msg)

    {
        if (msg.Exception is not CommandException cmdException) return Task.CompletedTask;
        
        Console.WriteLine($"[Command/{msg.Severity}] {cmdException.Command.Aliases[0]}" +
                          $" failed to execute in {cmdException.Context.Channel}.");
        Console.WriteLine(cmdException);

        return Task.CompletedTask;
    }

    [SuppressMessage("ReSharper", "MemberCanBeMadeStatic.Global")]
    [SuppressMessage("Performance", "CA1822:Mark members as static")]
    public Task ClientLogger(LogMessage msg)
    {
        
        return Task.CompletedTask;
    }
}