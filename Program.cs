using Discord;
using Discord.WebSocket;
using Discord.Interactions;
using System;
using System.Threading.Tasks;

namespace DiscordBot
{
    class Program
    {
        private DiscordSocketClient _client;
        private InteractionService _interactionService;
        private IServiceProvider _services;

        static void Main(string[] args) => new Program().RunBotAsync().GetAwaiter().GetResult();

        public async Task RunBotAsync()
        {
            var config = new DiscordSocketConfig
            {
                GatewayIntents = GatewayIntents.AllUnprivileged | GatewayIntents.MessageContent
            };

            _client = new DiscordSocketClient(config);
            _interactionService = new InteractionService(_client.Rest);

            _client.Log += Log;
            _client.Ready += RegisterCommandsAsync;

            // Fetch the bot token from the environment variable
            var token = Environment.GetEnvironmentVariable("DISCORD_TOKEN");

            if (string.IsNullOrWhiteSpace(token))
            {
                Console.WriteLine("Error: DISCORD_TOKEN environment variable is not set.");
                return;
            }

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            _client.InteractionCreated += HandleInteraction;

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

        private async Task RegisterCommandsAsync()
        {
            var confesarCommand = new SlashCommandBuilder()
                .WithName("confesar")
                .WithDescription("Confess something anonymously")
                .AddOption("text", ApplicationCommandOptionType.String, "The text to confess", isRequired: true);

            await _client.Rest.CreateGlobalCommand(confesarCommand.Build());

            Console.WriteLine("Slash command /confesar registered");
        }

        private async Task HandleInteraction(SocketInteraction interaction)
        {
            if (interaction is SocketSlashCommand command)
            {
                if (command.CommandName == "confesar")
                {
                    var text = command.Data.Options.First().Value.ToString();
                    await command.RespondAsync(text, ephemeral: true); // Responds privately
                    await command.Channel.SendMessageAsync(text); // Sends the message in the channel
                }
            }
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}