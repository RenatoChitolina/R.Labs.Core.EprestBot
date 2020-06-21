using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Builder.TraceExtensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace R.Labs.Core.EprestBot
{
    public class AdapterWithErrorHandler : BotFrameworkHttpAdapter
    {
        private readonly ILogger<BotFrameworkHttpAdapter> _logger;

        public AdapterWithErrorHandler(
            IConfiguration configuration,
            ILogger<BotFrameworkHttpAdapter> logger
        )
            : base(configuration, logger)
            => OnTurnError = HandleErrorAsync;

        private async Task HandleErrorAsync(
            ITurnContext turnContext,
            Exception exception
        )
        {
            _logger.LogError(exception, $"[OnTurnError] unhandled error : {exception.Message}");

            await turnContext.SendActivityAsync("The bot encountered an error or bug.");

            await turnContext.SendActivityAsync("To continue to run this bot, please fix the bot source code.");

            await turnContext.TraceActivityAsync("OnTurnError Trace", exception.Message, "https://www.botframework.com/schemas/error", "TurnError");
        }
    }
}
