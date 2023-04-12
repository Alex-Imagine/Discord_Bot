using DSharpPlus;
using Microsoft.Extensions.Logging;

namespace Test_Bot_discord
{
    public static class BotConfig
    {
        public static DiscordClient client;
        private static readonly string token = "";
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
