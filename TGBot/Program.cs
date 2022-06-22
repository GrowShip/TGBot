using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using File = System.IO.File;

namespace TGBot
{
    class Program
    {
        // private static TelegramBotClient Bot;
        
        static async Task Main(string[] args)
        {
            string path = "/Users/ilya/Desktop/token.txt";
            var botClient = new TelegramBotClient(File.ReadAllText(path));

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
