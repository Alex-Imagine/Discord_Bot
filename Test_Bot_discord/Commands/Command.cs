using DSharpPlus;
namespace Test_Bot_discord.Commands
{
    public abstract class Command
    {
        public abstract string Name { get;  set; }
        public abstract void Execute(DiscordClient sender, DSharpPlus.EventArgs.MessageCreateEventArgs eventArgs);
        public virtual bool Contains(string Name)
        {
            return this.Name == Name;
        }
    }
}
