using DSharpPlus;
using DSharpPlus.Entities;
using System.Collections.Generic;
using ConsoleTables;
namespace Test_Bot_discord.Commands
{
    public class ShowCoordsCommand : Command
    {
        private Database database = new Database();
        private string name = "/show";
        private string botanswer = "";
        public override string Name { get => name;  set => name = value; }

        public override async void Execute(DiscordClient sender, DSharpPlus.EventArgs.MessageCreateEventArgs eventArgs)
        {
            DiscordChannel channel = await sender.GetChannelAsync(eventArgs.Channel.Id);
            DiscordEmbedBuilder builder = new DiscordEmbedBuilder();
            builder.Color = DiscordColor.Red;
            if (!BotConfig.isExecutting)
            {
                BotConfig.isExecutting = true;
                database.SetConnectionDatabase("places");
                var table = new ConsoleTable();
                List<string> column = new List<string>();
                column.Add("  X  ");
                column.Add("  Y  ");
                column.Add("  Z  ");
                column.Add("    Place_Type    ");
                column.Add("    Place_Name    ");
                table.AddColumn(column);
                
                List<Places> places = database.ExecuteQuery<Places>("SELECT * FROM places.coords_places", false) as List<Places>;

                if (BotConfig.isExecutting)
                {
                    foreach (Places place in places)
                    {
                        table.AddRow("  " + place.X + "  ", "  " + place.Y + "  ", "  " + place.Z + "  ", "    " + place.Place_Type + "    ", "    " + place.Place_Name + "    ");
                    }
                    botanswer = table.ToStringAlternative();


                }
                else botanswer = string.Empty;
                BotConfig.isExecutting = false;
               

            }
            else
            {
                botanswer = "Дождитесь завершения или отмены предыдущей команды";
            }
            builder.Description = botanswer;
            await eventArgs.Message.RespondAsync(builder);



        }
    }
}
