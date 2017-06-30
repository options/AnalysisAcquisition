#r "Newtonsoft.Json"

using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

public static async Task Run(Stream myBlob, string name, TraceWriter log)
{
    log.Info($"{name} file was generated");
    //log.Info($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");

    TextAnalyticsInfo t = new TextAnalyticsInfo();
    using (StreamReader reader = new StreamReader(myBlob))
    {
        t.text = (await reader.ReadToEndAsync()).Replace("\r", "");
    }

    string json = JsonConvert.SerializeObject(t);

    HttpClient client = new HttpClient();
    Uri textAnalyticsServer = new Uri(GetEnv("TEXT_ANALYTICS_SERVER"));

    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    await client.PostAsync(textAnalyticsServer, new ByteArrayContent(Encoding.UTF8.GetBytes(json)));
}

public class TextAnalyticsInfo
{
    public string text;
}

public static string GetEnv(string name)
{
    return System.Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
}