using Discord;
using Discord.WebSocket;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordDotNet
{
    class Program
    {
        private readonly DiscordSocketClient _client;
        static void Main(string[] args)
        {
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        public Program()
        {
            _client = new DiscordSocketClient();
            _client.Log += LogAsync;
            _client.Ready += onReady;
            _client.MessageReceived += onMessage;
        }

        public async Task MainAsync()
        {
            await _client.LoginAsync(TokenType.Bot, "ODgxMDM4NDkzMzgyNTAwMzgy.YSnBCQ.dbb5szpdgHLaR-29xCigSY2YlaI");
            await _client.StartAsync();

            await Task.Delay(Timeout.Infinite);
        }

        private Task LogAsync(LogMessage log)
        {
            Console.WriteLine(log.ToString());
            return Task.CompletedTask;
        }

        private Task onReady()
        {
            Console.WriteLine($"{_client.CurrentUser} is Running!!");
            return Task.CompletedTask;
        }

        private async Task onMessage(SocketMessage message)
        {
            if (message.Author.Id == _client.CurrentUser.Id)
            {
                return;
            }
            if (message.Content == "デュエル開始の宣言をしろ！")
            {
                await message.Channel.SendMessageAsync("デュエル開始ィィィ");
            }
        }
    }
}
