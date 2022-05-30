using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;


namespace TGBot
{
    class Program
    {
        // private static string token { get; set; } = System.IO.File.ReadAllText(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "token.txt"));
        // private static TelegramBotClient Bot;
        
        static async Task Main(string[] args)
        {
            var botClient = new TelegramBotClient("");

            using var cts = new CancellationTokenSource();
            
            // Bot = new TelegramBotClient(token);
            // using var cts = new CancellationTokenSource();

            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }
            };

            botClient.StartReceiving(MyFunction.HandleUpdateAsync,
                MyFunction.HandleErrorAsync,
                receiverOptions,
                cts.Token);

            var me = await botClient.GetMeAsync();

            Console.WriteLine($"Бот @{me.Username} запущен и ждет сообщений...");
            Console.ReadLine();

            cts.Cancel();
        }
    }
}
