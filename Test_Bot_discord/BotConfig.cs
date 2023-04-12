using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using Microsoft.Extensions.Logging;

namespace Test_Bot_discord
{
    public static class BotConfig
    {
        public static DiscordClient client;
        private static readonly string token = "OTg5MTU4NTExNTQ2MTA1OTM2.GLueN4.dgfDFGmsr5L25Xwasq0P90Itfr-y6Jc-Voco34";
        public static bool isExecutting = false;
        public async static void Configure()
        {
            if (client == null)
            {
                client = new DiscordClient(new DiscordConfiguration
                {
                    Token = token,
                    TokenType = TokenType.Bot,
                    MinimumLogLevel = LogLevel.Debug
                });
            }     
            await client.ConnectAsync();
            
        }

        
    }
}
