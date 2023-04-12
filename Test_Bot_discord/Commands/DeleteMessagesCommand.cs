using DSharpPlus;
namespace Test_Bot_discord.Commands
{
    public class DeleteMessagesCommand : Command
    {
        private string name = "/remove";
        private string botanswer;
        public override string Name { get => name;  set => name = value; }
        public override async void Execute(DiscordClient sender, DSharpPlus.EventArgs.MessageCreateEventArgs eventArgs)
        {
            var messages = await eventArgs.Channel.GetMessagesAsync(100);
            if (!BotConfig.isExecutting)
            {
                BotConfig.isExecutting = true;
                foreach (var message in messages)
                {
                    if (!BotConfig.isExecutting)
                    {
                        botanswer = "-1"; 
                        break;
                    }
                    if (!message.Pinned) await eventArgs.Channel.DeleteMessageAsync(message);
                    
                }
                if (botanswer != "-1") botanswer = "Удалено";

                
            }
            else
            {
                botanswer = "Дождитесь завершения или отмены предыдущей команды";
            }
            if (botanswer != "-1") await eventArgs.Message.RespondAsync(botanswer);
        }
    }
}
