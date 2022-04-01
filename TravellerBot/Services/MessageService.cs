using Discord.WebSocket;
using TravellerBot.Services.Interfaces;
using TravellerBot.Utils;

namespace TravellerBot.Services
{
    public class MessageService
    {
        private readonly SocketMessage message;
        private readonly IDebugService debugService;
        
        public MessageService(IDebugService debugService, SocketMessage message)
        {
            this.debugService = debugService;
            this.message = message;
        }

        private void HandleCommand(string command)
        {
            switch (command)
            {
                case "help":
                    message.Channel.SendMessageAsync("Help");
                    break;
                case "ping":
                    message.Channel.SendMessageAsync("Pong!");
                    break;
                case "debug":
                    message.Channel.SendMessageAsync(debugService.GetDebugInfo().ToString());
                    break;
                default:
                    message.Channel.SendMessageAsync("Unknown command");
                    break;
            }
        }

        public async Task ProcessMessageAsync()
        {
            string? PREFIX = Environment.GetEnvironmentVariable("PREFIX") ?? null;
            if (PREFIX == null) return;
            if (!message.Content.StartsWith(PREFIX)) return;
            List<string> args = message.Content.Substring(PREFIX.Length).Split(' ').ToList();
            args.RemoveAll(x => x == string.Empty);
            string command = ListUtils.Shift(args).ToLower();
            string messageContent = string.Join(" ", args);
            HandleCommand(command);
        }
    }
}
