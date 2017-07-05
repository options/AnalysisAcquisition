using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.IO;
using System.Collections.Generic;

namespace UboneBot.Dialogs
{
    [Serializable]
    internal class PdfAttachDialog : IDialog<object>
    {
        private readonly string initalMessage = "PDF 파일을 첨부해 주세요.";
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync(initalMessage);

            context.Wait(this.MessageReceivedAsync);
        }

        public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;

            if (message.Attachments != null && message.Attachments.Any())
            {
                var attachment = message.Attachments.First();
                using (HttpClient httpClient = new HttpClient())
                {
                    // Skype attachment URLs are secured by a JwtToken, so we need to pass the token from our bot.
                    if (message.ChannelId.Equals("skype", StringComparison.InvariantCultureIgnoreCase) && new Uri(attachment.ContentUrl).Host.EndsWith("skype.com"))
                    {
                        var token = await new MicrosoftAppCredentials().GetTokenAsync();
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }

                    // 1. 업로드된 이미지의 Stream 가져오기
                    var responseMessage = await httpClient.GetAsync(attachment.ContentUrl);
                    //var contentLenghtBytes = responseMessage.Content.Headers.ContentLength;

                    Stream contentStream = await responseMessage.Content.ReadAsStreamAsync();

                    // 2. 이미지를 BLOB에 저장
                    // 랜덤 이름을 만들어서 Azure Storage에 저장하기
                    string fileName = attachment.Name;
                    if(fileName.IndexOf('.') > -1)
                    {
                        string[] fs = fileName.Split(new char[]{'.'});
                        fileName = string.Format("{0}-{1}.{2}", fs[0], Guid.NewGuid().ToString(), fs[1]);
                    }
                    else
                    {
                        fileName = string.Format("{0}-{1}", fileName, Guid.NewGuid().ToString());
                    }

                    await context.PostAsync("문서를 업로드 하고 있습니다...");

                    Utils.UbqoneBlobHelper up = new Utils.UbqoneBlobHelper();
                    Uri fileUri = up.UploadFilesToAzureStorage(fileName, contentStream);

                    await context.PostAsync("업로드가 완료 되었습니다. \n" +
                        "이제 곧 Cognitive 분석이 시작되며, 분석이 끝나면 메일로 결과를 알려 드립니다.");

                    context.Done(0);
                    //await context.PostAsync($"Attachment of {attachment.ContentType} type and size of {contentLenghtBytes} bytes received.");
                }
            }
            else
            {
                await context.PostAsync("문서를 첨부하지 않아서 작업이 취소되었습니다.");
                context.Done(0);
            }

            context.Done(0);
        }    
    }
}