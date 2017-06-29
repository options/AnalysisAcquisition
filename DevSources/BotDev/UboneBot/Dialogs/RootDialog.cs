using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections.Generic;

namespace UboneBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        private const string PDFAttachOption = "PDF";
        private const string DOCAttachOption = "DOC";

        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("안녕하세요? UBONE의 문서 접수 Bot입니다\n문서를 등록하시겠습니까?");
            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            //this.ShowOptions(context);
            PromptDialog.Choice(context, this.OnOptionSelected, new List<string>() { PDFAttachOption, DOCAttachOption }, @"어떤 문서를 등록하시겠습니까?", "선택해 주세요", 3);
        }

        private async Task OnOptionSelected(IDialogContext context, IAwaitable<string> result)
        {
            try
            {
                string optionSelected = await result;

                switch (optionSelected)
                {
                    case PDFAttachOption:
                        context.Call(new PdfAttachDialog(), this.ResumeAfterOptionDialog);
                        break;
                    case DOCAttachOption:
                        context.Call(new EtcDialog(), this.ResumeAfterOptionDialog);
                        break;
                }
            }
            catch (TooManyAttemptsException ex)
            {
                await context.PostAsync($"Ooops! Too many attemps :(. But don't worry, I'm handling that exception and you can try again!");

                context.Wait(this.MessageReceivedAsync);
            }
        }

        private async Task ResumeAfterOptionDialog(IDialogContext context, IAwaitable<object> result)
        {
            try
            {
                var message = await result;
            }
            catch (Exception ex)
            {
                await context.PostAsync($"Error : {ex.Message}");
            }
            finally
            {
                context.Wait(this.MessageReceivedAsync);
            }
        }
    }
}