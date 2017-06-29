using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Microsoft.Azure;
using System.Net.Http;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace UboneBot.Dialogs
{
    [Serializable]
    public class EtcDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            //context.Fail(new NotImplementedException("아직 기능이 구현되지 않았습니다."));
            await context.PostAsync("아직 기능이 구현되지 않았습니다. 현재는 PDF만 가능합니다.");
            context.Done(0);
        }
    }
}