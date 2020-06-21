using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace R.Labs.Core.EprestBot.Bots
{
    public class EchoBot : ActivityHandler
    {
        protected override async Task OnMessageActivityAsync(
            ITurnContext<IMessageActivity> turnContext,
            CancellationToken cancellationToken
        )
        {
            //var receivedText = turnContext.Activity.Text;
            
            await turnContext.SendActivityAsync(
                MessageFactory.Text("Alright. I received your PR and I'm moving it..."),
                cancellationToken
            );
        }
    }
}
