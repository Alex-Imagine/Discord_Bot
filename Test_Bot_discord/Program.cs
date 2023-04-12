using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DSharpPlus;
using Test_Bot_discord.Commands;
using DSharpPlus.Entities;
namespace Test_Bot_discord
{
    public class Program
    {
        private static readonly List<Command> commands = new List<Command>();
        
        public static void Main(string[] args)
        {
           
            commands.Add(new HelloCommand());
            commands.Add(new DeleteMessagesCommand());
            commands.Add(new StopBotCommand());
            commands.Add(new ShowCoordsCommand());
          
            MainTask(args).ConfigureAwait(false).GetAwaiter().GetResult();

           
        }

        private async static Task MainTask(string[] args)
        {
            BotConfig.Configure();
            BotConfig.client.MessageCreated += Client_MessageCreated;            
            await Task.Delay(-1);
          
        }

        private static async Task Client_MessageCreated(DiscordClient sender, DSharpPlus.EventArgs.MessageCreateEventArgs eventArgs)
        {
            try
            {
                if (!eventArgs.Message.Author.IsBot)
                {
                    string message = eventArgs.Message.Content;
                    foreach (var command in commands)
                    {
                        if (command.Contains(message))
                        {
                            command.Execute(sender, eventArgs);
                        }
                    }

                }
            }
            catch(Exception e)
            {
                DiscordEmbedBuilder builder = new DiscordEmbedBuilder();
                builder.Color = DiscordColor.Red;
                builder.Description = e.ToString();
                await eventArgs.Message.RespondAsync(e.ToString());
            }                 
        }
    }
}
