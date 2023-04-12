using DSharpPlus;
using DSharpPlus.Entities;
namespace Test_Bot_discord.Commands
{
    public class HelloCommand : Command
    {
        private string name = "/hello";
        private string botanswer;
        public override string Name { get => name;  set => name = value; }

        public override async void Execute(DiscordClient sender, DSharpPlus.EventArgs.MessageCreateEventArgs eventArgs)
        {
            DiscordChannel channel = await sender.GetChannelAsync(eventArgs.Channel.Id);
            if (!BotConfig.isExecutting)
            {               
                botanswer = "Приветствую, " + eventArgs.Message.Author.Username;
            }
            else
            {
                botanswer = "Дождитесь завершения или отмены предыдущей команды";
            }
            await eventArgs.Message.RespondAsync(botanswer);
            

        }
    }
}
