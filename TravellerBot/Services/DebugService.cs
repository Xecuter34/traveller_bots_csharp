using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellerBot.Services.Interfaces;

namespace TravellerBot.Services
{
    public class DebugService : IDebugService
    {
        private DiscordSocketClient debugSocketClient;
        
        public DiscordSocketClient DebugSocketClient 
        {
            get => debugSocketClient;
            private set
            {
                debugSocketClient = value;
            }
        }

        public void SetDebugSocketClient(DiscordSocketClient discordSocketClient)
        {
            DebugSocketClient = discordSocketClient;
        }

        public object GetDebugInfo()
        {
            return new { Info = "Test" };
        }
    }
}
