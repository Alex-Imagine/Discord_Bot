using DSharpPlus;
namespace Test_Bot_discord.Commands
{
    public class StopBotCommand : Command
    {
        private string name = "/stop";
        private string botanswer;
        public override string Name { get => name;  set => name = value; }


        public override async void Execute(DiscordClient sender, DSharpPlus.EventArgs.MessageCreateEventArgs eventArgs)
        {
            BotConfig.isExecutting = false;
            botanswer = "Команда остановлена";
            await eventArgs.Message.RespondAsync(botanswer);
        }
    }
}
