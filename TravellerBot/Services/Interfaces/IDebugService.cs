using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellerBot.Services.Interfaces
{
    public interface IDebugService
    {
        public DiscordSocketClient DebugSocketClient { get; }
        public void SetDebugSocketClient(DiscordSocketClient discordSocketClient);
        public object GetDebugInfo();
    }
}
