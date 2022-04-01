using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using TravellerBot.Services;
using TravellerBot.Services.Interfaces;

ServiceProvider serviceProvider = new ServiceCollection()
    .AddLogging()
    .AddScoped<IDebugService, DebugService>(options => new DebugService())
    .BuildServiceProvider();

DiscordSocketClient _client;
DebugService? _debugService = null;

_client = new DiscordSocketClient();
_client.Ready += Ready;
_client.Log += Log;
_client.MessageReceived += MessageReceived;

string token = Environment.GetEnvironmentVariable("TOKEN") ?? "";

await _client.LoginAsync(TokenType.Bot, token);
await _client.StartAsync();
await Task.Delay(-1);

Task Ready()
{
    _debugService = serviceProvider.GetRequiredService<DebugService>();
    _debugService.SetDebugSocketClient(_client);
    return Task.CompletedTask;
}

Task Log(LogMessage message)
{
    Console.WriteLine(message);
    return Task.CompletedTask;
}

Task MessageReceived(SocketMessage message)
{
    if (_debugService == null) return Task.CompletedTask; 
    MessageService messageService = new MessageService(_debugService, message);
    messageService.ProcessMessageAsync();
    return Task.CompletedTask;
}
